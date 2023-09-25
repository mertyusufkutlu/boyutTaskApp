using System.ComponentModel.DataAnnotations.Schema;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Domain.Entities;

[Table(nameof(Customer), Schema = "boyut_be")]
public class Customer : BaseEntity
{
    public string Name { get; set; }

    // public ICollection<Order> Orders { get; set; }
}