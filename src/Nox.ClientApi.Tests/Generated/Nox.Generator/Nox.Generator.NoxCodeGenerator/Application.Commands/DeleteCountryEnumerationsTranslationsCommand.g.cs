// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
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

public class DeleteCountriesContinentsTranslationsCommandValidator : AbstractValidator<DeleteCountriesContinentsTranslationsCommand>
{
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public DeleteCountriesContinentsTranslationsCommandValidator()
    {
		RuleFor(x => x.CultureCode)
			.NotNull().NotEmpty()
			.WithMessage($"{nameof(DeleteCountriesContinentsTranslationsCommand)} : {nameof(DeleteCountriesContinentsTranslationsCommand.CultureCode)} is required."); 
		
		RuleFor(x => x.CultureCode)
			.Must(x => x != _defaultCultureCode)
			.WithMessage($"{nameof(DeleteCountriesContinentsTranslationsCommand)} : {nameof(DeleteCountriesContinentsTranslationsCommand.CultureCode)} cannot be the default culture code: {_defaultCultureCode.Value}.");
			
    }
}