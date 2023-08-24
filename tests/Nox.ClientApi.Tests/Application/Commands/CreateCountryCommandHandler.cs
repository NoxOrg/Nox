using Humanizer;

using Nox.Application.Commands;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;

/// <summary>
/// Example to extend a Nox command and change a request
/// For Request Validation, before command handler is executed use <see cref="IValidator"/> instead IValidator<CreateClientDatabaseNumberCommand>.
/// </summary>
public partial class CreateCountryCommandHandler
{
    protected override void OnExecuting(CreateCountryCommand request)
    {
        if (request.EntityDto.Population < 0)
        {
            request.EntityDto.Population = 0;
        }
    }

    /// <summary>
    /// Example to Ensure or validate invariants for an entity
    /// </summary>
    /// <param name="entity"></param>
    protected override void OnCompleted(Country entity)
    {
        entity.Name = Nox.Types.Text.From(entity.Name.Value.Titleize());
    }
}

