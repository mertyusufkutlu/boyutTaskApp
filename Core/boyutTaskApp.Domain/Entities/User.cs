using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Domain.Entities;

[Table(nameof(User), Schema = "boyut_be")]
public class User : BaseEntity
{

    [MaxLength(250)]
    public string? Email { get; set; }

    [MaxLength(64)]
    public string? PhoneNumber { get; set; }

    public ICollection<Basket> Baskets { get; set; }
}
