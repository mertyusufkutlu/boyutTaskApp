using System.ComponentModel.DataAnnotations.Schema;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Domain.Entities;

[Table(nameof(BasketItem), Schema = "boyut_be")]
public class BasketItem : BaseEntity
{
    public Guid? BasketId { get; set; }
    public Guid? ProductId { get; set; }

    public int Quantity { get; set; }
    
    public Basket Basket { get; set; }
    public Product Product { get; set; }
}