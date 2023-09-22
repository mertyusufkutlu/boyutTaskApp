using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace boyutTaskAppAPI.Domain.Entities.Common;

public abstract class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string? ExternalId { get; set; }

    public bool IsDeleted { get; set; } = false;
}

public abstract class TimestampedBaseEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}