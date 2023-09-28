namespace Nox.Domain;

public interface IDomainEvent
{
    public bool IsPublished { get; set; } 
}