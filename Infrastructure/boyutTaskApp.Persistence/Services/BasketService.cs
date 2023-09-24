using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Features.Commands.BasketItem;
using boyutTaskAppAPI.Applicaton.Repositories.Basket;
using boyutTaskAppAPI.Applicaton.Repositories.Order;
using boyutTaskAppAPI.Applicaton.Services;
using boyutTaskAppAPI.Domain.Entities;
using boyutTaskAppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace boyutTaskAppAPI.Persistence.Services
{
    public class BasketService : IBasketService
    {
        private readonly boyutTaskAppDbContext _boyutTaskAppDbContext;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IBasketWriteRepository _basketWriteRepository;

        public BasketService(boyutTaskAppDbContext boyutTaskAppDbContext, IOrderReadRepository orderReadRepository,
            IBasketWriteRepository basketWriteRepository)
        {
            _boyutTaskAppDbContext = boyutTaskAppDbContext;
            _orderReadRepository = orderReadRepository;
            _basketWriteRepository = basketWriteRepository;
        }

        public async Task<List<BasketItem>> GetBasketItemAsync(Guid userId)
        {
            var userBasketItems = await _boyutTaskAppDbContext.BasketItems
                .Where(b => b.Basket.UserId == userId) // Filter basket items for the user
                .Include(p => p.Product)
                .Include(b => b.Basket)
                .ThenInclude(o=>o.Order)
                .ToListAsync();

            return userBasketItems;
        }

        public async Task<CreateBasketItemResponse> AddItemToBasketAsync(CreateBasketItemRequest createBasketItemRequest)
        {
            // Find the user in the database or handle the error
            var user = await _boyutTaskAppDbContext.Users.FirstOrDefaultAsync(u =>
                u.Id == createBasketItemRequest.UserId);
            if (user == null)
            {
                throw new BaseException("User not found");
            }

            // Find the product in the database
            var product =
                await _boyutTaskAppDbContext.Products.FirstOrDefaultAsync(
                    p => p.Id == createBasketItemRequest.ProductId);
            if (product == null)
            {
                // Product not found error
                throw new BaseException("Product not found");
            }

            // Get the user's basket or create a new one if it doesn't exist
            var basket = await _boyutTaskAppDbContext.Baskets
                .FirstOrDefaultAsync(b => b.UserId == createBasketItemRequest.UserId);

            if (basket == null)
            {
                basket = new Basket
                {
                    UserId = createBasketItemRequest.UserId
                };
                _boyutTaskAppDbContext.Baskets.Add(basket);
            }

            // Create a BasketItem
            var basketItem = new BasketItem
            {
                BasketId = basket.Id,
                ProductId = createBasketItemRequest.ProductId,
                Quantity = createBasketItemRequest.Quantity
            };

            _boyutTaskAppDbContext.BasketItems.Add(basketItem);

            // SaveChanges
            await _boyutTaskAppDbContext.SaveChangesAsync();

            return new CreateBasketItemResponse()
            {
                Quantity = basketItem.Quantity,
                BasketItemId = basketItem.Id,
                ProductId = (Guid)basketItem.ProductId
            };
        }

        public async Task<bool> UpdateQuantityAsync(UpdateBasketItemRequest updateBasketItemRequest)
        {
            // Find the basketItem
            var basketItem =
                await _boyutTaskAppDbContext.BasketItems.FirstOrDefaultAsync(bi =>
                    bi.Id == updateBasketItemRequest.BasketItemId);

            if (basketItem == null)
            {
                // BasketItem not found exception
                throw new BaseException("BasketItem not found");
            }

            // Update the quantity
            basketItem.Quantity = updateBasketItemRequest.Quantity;

            // SaveChanges
            await _boyutTaskAppDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveBasketItemAsync(Guid basketItemId)
        {
            var basketItem = await _boyutTaskAppDbContext.BasketItems.FirstOrDefaultAsync(bi => bi.Id == basketItemId);

            if (basketItem == null)
            {
                throw new BaseException("BasketItem not found");
            }

            _boyutTaskAppDbContext.BasketItems.Remove(basketItem);

            await _boyutTaskAppDbContext.SaveChangesAsync();
            return true;
        }
    }
}