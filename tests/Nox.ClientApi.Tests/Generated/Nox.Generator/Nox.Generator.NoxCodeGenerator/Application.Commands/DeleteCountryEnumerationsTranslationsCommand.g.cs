// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Abstractions.Extensions;
using ClientApi.Domain;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;
public partial record  DeleteCountriesContinentsTranslationsCommand(Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteCountriesContinentsTranslationsCommandHandler : DeleteCountriesContinentsTranslationsCommandHandlerBase
{
	public DeleteCountriesContinentsTranslationsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCountriesContinentsTranslationsCommandHandlerBase : CommandCollectionBase<DeleteCountriesContinentsTranslationsCommand, CountryContinentLocalized>, IRequestHandler<DeleteCountriesContinentsTranslationsCommand, bool>
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

		var localizedEnums = await Repository.Query<CountryContinentLocalized>().Where(x => x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
		
		if(!localizedEnums.Any())
		{
			return false;
		}
		
		await OnCompletedAsync(command, localizedEnums);
		
		Repository.DeleteRange(localizedEnums);
		
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