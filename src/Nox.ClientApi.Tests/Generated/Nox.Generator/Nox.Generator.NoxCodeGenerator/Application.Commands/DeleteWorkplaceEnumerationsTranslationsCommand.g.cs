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
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;
public partial record  DeleteWorkplacesOwnershipsTranslationsCommand(Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteWorkplacesOwnershipsTranslationsCommandHandler : DeleteWorkplacesOwnershipsTranslationsCommandHandlerBase
{
	public DeleteWorkplacesOwnershipsTranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteWorkplacesOwnershipsTranslationsCommandHandlerBase : CommandCollectionBase<DeleteWorkplacesOwnershipsTranslationsCommand, WorkplaceOwnershipLocalized>, IRequestHandler<DeleteWorkplacesOwnershipsTranslationsCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteWorkplacesOwnershipsTranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteWorkplacesOwnershipsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);

		var localizedEnums = await DbContext.WorkplacesOwnershipsLocalized.Where(x => x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
		
		if(!localizedEnums.Any())
		{
			return false;
		}
		
		await OnCompletedAsync(command, localizedEnums);
		
		DbContext.RemoveRange(localizedEnums);
		
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}

public class DeleteWorkplacesOwnershipsTranslationsCommandValidator : AbstractValidator<DeleteWorkplacesOwnershipsTranslationsCommand>
{
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public DeleteWorkplacesOwnershipsTranslationsCommandValidator()
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x != _defaultCultureCode)
			.WithMessage($"{nameof(DeleteWorkplacesOwnershipsTranslationsCommand)} : {nameof(DeleteWorkplacesOwnershipsTranslationsCommand.CultureCode)} cannot be the default culture code: {_defaultCultureCode.Value}.");
			
    }
}