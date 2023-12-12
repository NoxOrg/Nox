namespace Nox.Integration.Abstractions.Interfaces;

public interface IEtlEvent<TDto>
{
    string? IntegrationName { get; internal set; }
    
    TDto? Dto { get; }

    void SetDto(TDto dto);
}