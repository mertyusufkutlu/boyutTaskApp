using System.ComponentModel.DataAnnotations.Schema;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Domain.Entities;

[Table(nameof(ProductGroup), Schema = "boyut_be")]
public class ProductGroup : BaseEntity
{
    public string Name { get; set; }
}