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
using ClientApi.Domain;
using CountryLocalizedEntity = ClientApi.Domain.CountryLocalized;

namespace ClientApi.Application.Commands;

public partial record  DeleteCountryTranslationCommand(System.Int64 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteCountryTranslationCommandHandler : DeleteCountryTranslationCommandHandlerBase
{
    public DeleteCountryTranslationCommandHandler(
           IRepository repository,
                  NoxSolution noxSolution) : base(repository, noxSolution)
    {
    }
}

internal abstract class DeleteCountryTranslationCommandHandlerBase : CommandBase<DeleteCountryTranslationCommand, CountryLocalizedEntity>, IRequestHandler<DeleteCountryTranslationCommand, bool>
{
    public IRepository Repository { get; }

    public DeleteCountryTranslationCommandHandlerBase(
           IRepository repository,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        Repository = repository;
    }

    public virtual async Task<bool> Handle(DeleteCountryTranslationCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
		var keyId = Dto.CountryMetadata.CreateId(command.keyId);
        
        var entity = await Repository.FindAsync<ClientApi.Domain.Country>(keyId);
        EntityNotFoundException.ThrowIfNull(entity, "Country", $"{keyId.ToString()}");
		
        var entityLocalized = await Repository.Query<CountryLocalized>().FirstOrDefaultAsync(x =>x.Id == entity.Id && x.CultureCode == command.CultureCode);
        EntityLocalizationNotFoundException.ThrowIfNull(entityLocalized, "Country",  $"{keyId.ToString()}", command.CultureCode.ToString());
        
        Repository.Delete(entityLocalized);
        await OnCompletedAsync(command, entityLocalized);
        await Repository.SaveChangesAsync(cancellationToken);
        return true;
    }
}

public class DeleteCountryTranslationCommandValidator : AbstractValidator<DeleteCountryTranslationCommand>
{
    public DeleteCountryTranslationCommandValidator(NoxSolution noxSolution)
    {
        var defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);

		RuleFor(x => x.CultureCode)
			.Must(x => x != defaultCultureCode)
			.WithMessage($"{nameof(DeleteCountryTranslationCommand)} : {nameof(DeleteCountryTranslationCommand.CultureCode)} cannot be the default culture code: {defaultCultureCode.Value}.");
			
    }
}	