using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Abstractions.Models;

public record EtlExecuteCompletedDto: IEtlEventDto
{
    public int Inserts { get; set; }
    public int Updates { get; set; }
    public int Unchanged { get; set; }
}