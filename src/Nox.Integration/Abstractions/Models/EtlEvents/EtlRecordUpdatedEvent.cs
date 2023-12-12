using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Abstractions.Models;

public class EtlRecordUpdatedEvent<TDto>: IEtlEvent<TDto> where TDto: IEtlEventDto
{
    private TDto? _dto;
    
    public string? IntegrationName { get; set; }
    
    public TDto? Dto => _dto;
    
    public void SetDto(TDto payload)
    {
        _dto = payload;
    }
}