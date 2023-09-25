using System.ComponentModel.DataAnnotations.Schema;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Domain.Entities;

[Table(nameof(Order), Schema = "boyut_be")]
public class Order : BaseEntity
{
    // public Guid CustomerId { get; set; }

    // public Guid BasketId { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }

    public Basket Basket { get; set; }

    // public ICollection<Product> Products { get; set; }
    // public Customer Customer { get; set; }
    
}