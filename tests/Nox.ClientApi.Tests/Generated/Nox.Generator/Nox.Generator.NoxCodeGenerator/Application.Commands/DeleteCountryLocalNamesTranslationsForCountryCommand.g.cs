// Generated

#nullable enable
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;
using Nox.Extensions;

using ClientApi.Domain;
using CountryLocalNameLocalizedEntity = ClientApi.Domain.CountryLocalNameLocalized;

namespace ClientApi.Application.Commands;

public partial record  DeleteCountryLocalNamesTranslationsForCountryCommand(System.Int64 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteCountryLocalNamesTranslationsForCountryCommandHandler : DeleteCountryLocalNamesTranslationsForCountryCommandHandlerBase
{
    public DeleteCountryLocalNamesTranslationsForCountryCommandHandler(
           IRepository repository,
                  NoxSolution noxSolution) : base(repository, noxSolution)
    {
    }
}

internal abstract class DeleteCountryLocalNamesTranslationsForCountryCommandHandlerBase : CommandCollectionBase<DeleteCountryLocalNamesTranslationsForCountryCommand, CountryLocalNameLocalizedEntity>, IRequestHandler<DeleteCountryLocalNamesTranslationsForCountryCommand, bool>
{
    public IRepository Repository { get; }

    public DeleteCountryLocalNamesTranslationsForCountryCommandHandlerBase(
           IRepository repository,
           NoxSolution noxSolution) : base(noxSolution)
    {
        Repository = repository;
    }

    public virtual async Task<bool> Handle(DeleteCountryLocalNamesTranslationsForCountryCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
        
        var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(command.keyId));

        var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(), p => p.CountryLocalNames,cancellationToken);
        EntityNotFoundException.ThrowIfNull(parentEntity, "Country", "parentKeyId");
        var entityKeys = parentEntity.CountryLocalNames.Select(x => x.Id).ToList();
        var entities = await Repository.Query<CountryLocalNameLocalized>().Where(x => entityKeys.Contains(x.Id) && x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
        
        if (!entities.Any())
        {
            throw new EntityLocalizationNotFoundException("Country.CountryLocalNames",  String.Empty, command.CultureCode.ToString());
        }

        Repository.DeleteRange(entities);
        await OnCompletedAsync(command, entities);        
        
        await Repository.SaveChangesAsync(cancellationToken);
        return true;
    }
}

public class DeleteCountryLocalNamesTranslationsForCountryCommandValidator : AbstractValidator<DeleteCountryLocalNamesTranslationsForCountryCommand>
{
    public DeleteCountryLocalNamesTranslationsForCountryCommandValidator(NoxSolution noxSolution)
    {
        var defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);

		RuleFor(x => x.CultureCode)
			.Must(x => x != defaultCultureCode)
			.WithMessage($"{nameof(DeleteCountryLocalNamesTranslationsForCountryCommand)} : {nameof(DeleteCountryLocalNamesTranslationsForCountryCommand.CultureCode)} cannot be the default culture code: {defaultCultureCode.Value}.");
			
    }
}