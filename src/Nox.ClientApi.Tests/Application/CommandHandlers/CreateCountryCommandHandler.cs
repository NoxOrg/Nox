using ClientApi.Domain;
using Humanizer;

namespace ClientApi.Application.Commands;

/// <summary>
/// Example to extend a Nox command and change a request
/// For Request Validation, before command handler is executed use <see cref="IValidator"/> instead IValidator<CreateClientAutoNumberCommand>.
/// </summary>
internal partial class CreateCountryCommandHandler
{
    protected override Task OnExecutingAsync(CreateCountryCommand request)
    {
        if (request.EntityDto.Population < 0)
        {
            request.EntityDto.Population = 0;
        }
        return Task.CompletedTask;
    }

    /// <summary>
    /// Example to Ensure or validate invariants for an entity
    /// </summary>
    protected override Task OnCompletedAsync(CreateCountryCommand request,Country entity)
    {
         entity.Name = Nox.Types.Text.From(char.ToUpper(entity.Name.Value[0]) + entity.Name.Value.Substring(1));

        return Task.CompletedTask;
    }
}

