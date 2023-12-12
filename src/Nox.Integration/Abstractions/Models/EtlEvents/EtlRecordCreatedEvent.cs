using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Abstractions.Models;

public class EtlRecordCreatedEvent<TDto>: IEtlEvent<TDto> where TDto: IEtlEventDto
{
    private TDto? _dto;
    
    public string? IntegrationName { get; set; }
    
    public void SetDto(TDto dto)
    {
        _dto = dto;
    }

    public TDto? Dto => _dto;
}