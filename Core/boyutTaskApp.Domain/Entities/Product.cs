using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Domain.Entities;

[Table(nameof(Product), Schema = "boyut_be")]
public class Product : BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }

    public Guid? ProductGroupId { get; set; }

    public ProductGroup? ProductGroup { get; set; }

    public ICollection<Order>? Orders { get; set; }
}