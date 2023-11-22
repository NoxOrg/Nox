using ClientApi.Application.Dto;
using ClientApi.Application.Exceptions;

namespace ClientApi.Application.Commands;

/// <summary>
/// Example how to add an additional property to a command
/// </summary>
public partial record CreateCountryLocalNamesForCountryCommand
{
    public string AlternativeName { get; set; } = string.Empty;
}


internal partial class CreateCountryLocalNamesForCountryCommandHandler
{
    public override async Task<CountryLocalNameKeyDto?> Handle(
        CreateCountryLocalNamesForCountryCommand request,
        CancellationToken cancellationToken
        )
    {
        /// Example how to use the custom field added to the default request
        if (string.IsNullOrEmpty(request.AlternativeName))
        {
            //Example how to customize the returned status code, and error code
            throw new CountryNameInvalid()
            {
                ErrorDetails = new
                {
                    Name = request.EntityDto.Name,
                    NativeName = request.EntityDto.NativeName,
                    Message = "AlternativeName is required, name and native name are not sufficient!"
                }
            };
        }
        return await base.Handle(request, cancellationToken);
    }
}