using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using boyutTaskAppAPI.Domain.Entities.Common;

namespace boyutTaskAppAPI.Domain.Entities;

[Table(nameof(User), Schema = "sg_be")]
public class User : BaseEntity
{
    [MaxLength(250)]
    public string? UserName { get; set; }

    [MaxLength(250)]
    public string? Email { get; set; }

    [MaxLength(64)]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Alpha3 country code
    /// </summary>
    [MaxLength(3)]
    public string? Nationality { get; set; }
    
    public string? PhotoUrl { get; set; }
    
    public DateTime? BirthDate { get; set; }
}
