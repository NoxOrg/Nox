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
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;
public partial record  DeleteWorkplacesOwnershipsTranslationsCommand(Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteWorkplacesOwnershipsTranslationsCommandHandler : DeleteWorkplacesOwnershipsTranslationsCommandHandlerBase
{
	public DeleteWorkplacesOwnershipsTranslationsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteWorkplacesOwnershipsTranslationsCommandHandlerBase : CommandCollectionBase<DeleteWorkplacesOwnershipsTranslationsCommand, WorkplaceOwnershipLocalized>, IRequestHandler<DeleteWorkplacesOwnershipsTranslationsCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteWorkplacesOwnershipsTranslationsCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteWorkplacesOwnershipsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);

		var localizedEnums = await Repository.Query<WorkplaceOwnershipLocalized>().Where(x => x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
		
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

public class DeleteWorkplacesOwnershipsTranslationsCommandValidator : AbstractValidator<DeleteWorkplacesOwnershipsTranslationsCommand>
{
	public DeleteWorkplacesOwnershipsTranslationsCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x.Value != noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName())
			.WithMessage($"{nameof(DeleteWorkplacesOwnershipsTranslationsCommand)} : {nameof(DeleteWorkplacesOwnershipsTranslationsCommand.CultureCode)} cannot be the default culture code: {noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName()}.");
			
    }
}