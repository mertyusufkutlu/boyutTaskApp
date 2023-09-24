using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Domain.Entities;

[Table(nameof(Basket), Schema = "boyut_be")]
public class Basket : BaseEntity
{
    public Guid UserId { get; set; }
    
    public User User { get; set; }

    public Guid OrderId { get; set; }

    public Order Order { get; set; }

    public ICollection<BasketItem> BasketItems { get; set; }
}