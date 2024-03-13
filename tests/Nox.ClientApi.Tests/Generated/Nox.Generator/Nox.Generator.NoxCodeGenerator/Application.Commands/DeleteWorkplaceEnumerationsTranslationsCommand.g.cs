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
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;
public partial record  DeleteWorkplacesOwnershipsTranslationsCommand(Enumeration Id, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteWorkplacesOwnershipsTranslationsCommandHandler : DeleteWorkplacesOwnershipsTranslationsCommandHandlerBase
{
	public DeleteWorkplacesOwnershipsTranslationsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteWorkplacesOwnershipsTranslationsCommandHandlerBase : CommandBase<DeleteWorkplacesOwnershipsTranslationsCommand, WorkplaceOwnershipLocalized>, IRequestHandler<DeleteWorkplacesOwnershipsTranslationsCommand, bool>
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
		
		var enumEntity = await Repository.FindAsync<WorkplaceOwnership>(command.Id, cancellationToken);
        EntityNotFoundException.ThrowIfNull(enumEntity, "WorkplaceOwnershipLocalized", command.Id.Value.ToString());

		var localizedEnum = await Repository.Query<WorkplaceOwnershipLocalized>()
			.FirstOrDefaultAsync(x => x.Id == command.Id && x.CultureCode == command.CultureCode, cancellationToken);
		EntityLocalizationNotFoundException.ThrowIfNull(localizedEnum, "WorkplaceOwnershipLocalized",  command.Id.Value.ToString(), command.CultureCode.ToString());
		
		Repository.Delete(localizedEnum);

        await OnCompletedAsync(command, localizedEnum);
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