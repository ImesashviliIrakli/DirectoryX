using System.ComponentModel.DataAnnotations;

namespace Domain.Abstractions;

public abstract class Entity
{
    [Key]
    public int Id { get; init; }

    protected Entity() {}
}
