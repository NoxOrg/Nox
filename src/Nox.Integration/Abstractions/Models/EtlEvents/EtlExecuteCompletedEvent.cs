using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Abstractions.Models;

public class EtlExecuteCompletedEvent: IEtlEvent<EtlExecuteCompletedDto>
{
    private EtlExecuteCompletedDto? _dto;
    
    public string? IntegrationName { get; set; }

    public EtlExecuteCompletedDto? Dto => _dto;
    
    public void SetDto(EtlExecuteCompletedDto dto)
    {
        _dto = dto;
    }
}