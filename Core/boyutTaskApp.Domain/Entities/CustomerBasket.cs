using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Domain.Entities;

[Table(nameof(CustomerBasket), Schema = "boyut_be")]
public class CustomerBasket : BaseEntity
{
    public Guid UserId { get; set; }
    
    public User User { get; set; }
    
    public Guid ProductId { get; set; }
    
    public Product Product { get; set; }
}