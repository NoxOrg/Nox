// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Exceptions;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;
public partial record  DeleteCountriesContinentsTranslationsCommand(Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteCountriesContinentsTranslationsCommandHandler : DeleteCountriesContinentsTranslationsCommandHandlerBase
{
	public DeleteCountriesContinentsTranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCountriesContinentsTranslationsCommandHandlerBase : CommandBase<DeleteCountriesContinentsTranslationsCommand, CountryContinentLocalized>, IRequestHandler<DeleteCountriesContinentsTranslationsCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCountriesContinentsTranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountriesContinentsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);

		if(NoxSolution.Application?.Localization?.DefaultCulture == command.CultureCode.Value)
		{
			throw new DefaultCultureCodeDeletionException($"Default culture code {command.CultureCode.Value} cannot be deleted.");
		}
		
		var localizedEnums = await DbContext.CountriesContinentsLocalized.Where(x => x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
		
		if(localizedEnums == null || localizedEnums.Count == 0)
		{
			return false;
		}
		
		await OnBatchCompletedAsync(command, localizedEnums);
		
		DbContext.RemoveRange(localizedEnums);
		
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}