using boyutTaskAppAPI.Applicaton.Base;
using boyutTaskAppAPI.Applicaton.Features.Commands.Order;
using boyutTaskAppAPI.Applicaton.Repositories.Order;
using boyutTaskAppAPI.Applicaton.Services;
using boyutTaskAppAPI.Domain.Entities;
using boyutTaskAppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace boyutTaskAppAPI.Persistence.Services;

public class OrderService : IOrderService
{
    private readonly IOrderWriteRepository _orderWriteRepositor;
    private readonly boyutTaskAppDbContext _boyutTaskAppDbContext;

    public OrderService(IOrderWriteRepository orderWriteRepositor, boyutTaskAppDbContext boyutTaskAppDbContext)
    {
        _orderWriteRepositor = orderWriteRepositor;
        _boyutTaskAppDbContext = boyutTaskAppDbContext;
    }

    public async Task<CreateOrderCommandResponse> CreateOrderAsync(CreateOrderCommandRequest createOrderCommandRequest)
    {
        var order = new Order
        {
            Adress = createOrderCommandRequest.Adress,
            Id = createOrderCommandRequest.BasketId,
            Description = createOrderCommandRequest.Description
        };

        var savedOrder = await _boyutTaskAppDbContext.Orders.AddAsync(order);
        
        await _boyutTaskAppDbContext.SaveChangesAsync();

        // Ürün miktarını güncelle
        var basketItems = await _boyutTaskAppDbContext.BasketItems
            .Where(item => item.BasketId == createOrderCommandRequest.BasketId)
            .ToListAsync();

        foreach (var basketItem in basketItems)
        {
            // İlgili ürünün miktarını güncelle
            var product = await _boyutTaskAppDbContext.Products.FindAsync(basketItem.ProductId);
            if (product != null && product.Stock != 0)
            {
                product.Stock -= basketItem.Quantity;
            }
            else
            {
                throw new BaseException("Stock quantity cannot be less than 0");
            }
        }

        await _boyutTaskAppDbContext.SaveChangesAsync();

        return new CreateOrderCommandResponse()
        {
            OrderId = savedOrder.Entity.Id,
            Description = savedOrder.Entity.Description,
            Adress = savedOrder.Entity.Adress
        };
    }
}