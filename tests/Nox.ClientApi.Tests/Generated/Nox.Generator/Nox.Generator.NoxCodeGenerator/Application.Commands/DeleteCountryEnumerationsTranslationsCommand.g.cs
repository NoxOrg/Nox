// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Domain;
using Nox.Exceptions;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Abstractions.Extensions;
using ClientApi.Domain;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;
public partial record  DeleteCountriesContinentsTranslationsCommand(Enumeration Id, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteCountriesContinentsTranslationsCommandHandler : DeleteCountriesContinentsTranslationsCommandHandlerBase
{
	public DeleteCountriesContinentsTranslationsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCountriesContinentsTranslationsCommandHandlerBase : CommandBase<DeleteCountriesContinentsTranslationsCommand, CountryContinentLocalized>, IRequestHandler<DeleteCountriesContinentsTranslationsCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCountriesContinentsTranslationsCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCountriesContinentsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var enumEntity = await Repository.FindAsync<CountryContinent>(command.Id, cancellationToken);
        EntityNotFoundException.ThrowIfNull(enumEntity, "CountryContinentLocalized", command.Id.Value.ToString());

		var localizedEnum = await Repository.Query<CountryContinentLocalized>()
			.FirstOrDefaultAsync(x => x.Id == command.Id && x.CultureCode == command.CultureCode, cancellationToken);
		EntityLocalizationNotFoundException.ThrowIfNull(localizedEnum, "CountryContinentLocalized",  command.Id.Value.ToString(), command.CultureCode.ToString());
		
		Repository.Delete(localizedEnum);

        await OnCompletedAsync(command, localizedEnum);
        await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}

public class DeleteCountriesContinentsTranslationsCommandValidator : AbstractValidator<DeleteCountriesContinentsTranslationsCommand>
{
	public DeleteCountriesContinentsTranslationsCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x.Value != noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName())
			.WithMessage($"{nameof(DeleteCountriesContinentsTranslationsCommand)} : {nameof(DeleteCountriesContinentsTranslationsCommand.CultureCode)} cannot be the default culture code: {noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName()}.");
			
    }
}