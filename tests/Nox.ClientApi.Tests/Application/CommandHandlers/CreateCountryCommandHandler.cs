using System.Linq.Expressions;
using ClientApi.Domain;
using FluentValidation;
using Nox.Exceptions;

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

internal partial class DeleteAllCountryLocalNamesForCountryCommandHandler
{
    public override  Task<bool> Handle(DeleteAllCountryLocalNamesForCountryCommand request, CancellationToken cancellationToken)
    {
        // cancellationToken.ThrowIfCancellationRequested();
        // await OnExecutingAsync(request);
		      //
        // var keys = new List<object?>(1);
        // keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));
		      //
        // // var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(), p => p.CountryLocalNames , cancellationToken);
        // var parentEntity = await 
        //     Repository.FindAndIncludeAsync<ClientApi.Domain.Country,ClientApi.Domain.CountryLocalName, ClientApi.Domain.CountryLocalNameLocalized >(
        //         keys.ToArray(), 
        //         p => p.CountryLocalNames, 
        //         l => l.LocalizedCountryLocalNames , 
        //         cancellationToken);
        // EntityNotFoundException.ThrowIfNull(parentEntity, "Country", "parentKeyId");
		      //
        // var entities = parentEntity.CountryLocalNames;
        //
        //
        // // foreach (var countryLocalName in entities)
        // // {
        // //     await Repository.IncludeAsync(countryLocalName, p => p.LocalizedCountryLocalNames, cancellationToken);
        // // }
        //
        // Repository.DeleteOwned(entities);
		      //
        // parentEntity.DeleteAllRefToCountryLocalNames();
        // parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		      //
        // await OnCompletedAsync(request, parentEntity);
        // Repository.Update(parentEntity);
        // await Repository.SaveChangesAsync(cancellationToken);
        //
        //  // base.Handle(request, cancellationToken);
        // return true;
         return base.Handle(request, cancellationToken);
    }
}

