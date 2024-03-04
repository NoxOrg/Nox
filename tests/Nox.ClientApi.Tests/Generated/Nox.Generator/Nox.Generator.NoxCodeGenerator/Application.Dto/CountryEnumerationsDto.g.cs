// Generated
#nullable enable

using System.Data.Common;
namespace ClientApi.Application.Dto;

public partial record CountryContinentDto: Nox.Application.Dto.EnumerationDtoBase
{    
   
}
public partial record CountryContinentLocalizedDto: Nox.Application.Dto.EnumerationLocalizedDtoBase
{
    
}

public partial record CountryContinentLocalizedUpsertDto: Nox.Application.Dto.EnumerationLocalizedUpsertDtoBase
{

}

public record CountryContinentLocalizedKeyDto(System.Int32 Id, System.String cultureCode);
