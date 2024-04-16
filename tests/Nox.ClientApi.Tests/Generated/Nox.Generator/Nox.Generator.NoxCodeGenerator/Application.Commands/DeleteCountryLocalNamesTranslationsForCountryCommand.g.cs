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

public partial record  DeleteCountryLocalNamesTranslationsForCountryCommand(System.Int64 keyId, System.Int64 relatedKeyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteCountryLocalNamesTranslationsForCountryCommandHandler : DeleteCountryLocalNamesTranslationsForCountryCommandHandlerBase
{
    public DeleteCountryLocalNamesTranslationsForCountryCommandHandler(
        IRepository repository,
        NoxSolution noxSolution)
        : base(repository, noxSolution)
    {
    }
}

internal abstract class DeleteCountryLocalNamesTranslationsForCountryCommandHandlerBase : CommandBase<DeleteCountryLocalNamesTranslationsForCountryCommand, CountryLocalNameLocalizedEntity>, IRequestHandler<DeleteCountryLocalNamesTranslationsForCountryCommand, bool>
{
    public IRepository Repository { get; }

    public DeleteCountryLocalNamesTranslationsForCountryCommandHandlerBase(
        IRepository repository,
        NoxSolution noxSolution) 
        : base(noxSolution)
    {
        Repository = repository;
    }

    public virtual async Task<bool> Handle(DeleteCountryLocalNamesTranslationsForCountryCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
        
        var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(command.keyId));

        var parentEntity = await Repository.FindAsync<ClientApi.Domain.Country>(keys.ToArray(), cancellationToken);
        EntityNotFoundException.ThrowIfNull(parentEntity, "Country", "parentKeyId");

        var entity = await Repository.Query<ClientApi.Domain.CountryLocalNameLocalized>().SingleOrDefaultAsync(x => x.Id == Dto.CountryLocalNameMetadata.CreateId(command.relatedKeyId) && x.CultureCode == command.CultureCode, cancellationToken);
                EntityLocalizationNotFoundException.ThrowIfNull(entity, "Country.CountryLocalNames", "entityKeyId", command.CultureCode.ToString());
        
        Repository.Delete(entity);
        await OnCompletedAsync(command, entity);
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