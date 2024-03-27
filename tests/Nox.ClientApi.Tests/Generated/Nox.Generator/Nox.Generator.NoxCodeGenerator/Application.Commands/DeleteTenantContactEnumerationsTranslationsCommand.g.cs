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
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Commands;
public partial record  DeleteTenantContactsStatusesTranslationsCommand(Enumeration Id, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTenantContactsStatusesTranslationsCommandHandler : DeleteTenantContactsStatusesTranslationsCommandHandlerBase
{
	public DeleteTenantContactsStatusesTranslationsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTenantContactsStatusesTranslationsCommandHandlerBase : CommandBase<DeleteTenantContactsStatusesTranslationsCommand, TenantContactStatusLocalized>, IRequestHandler<DeleteTenantContactsStatusesTranslationsCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTenantContactsStatusesTranslationsCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTenantContactsStatusesTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var enumEntity = await Repository.FindAsync<TenantContactStatus>(command.Id, cancellationToken);
        EntityNotFoundException.ThrowIfNull(enumEntity, "TenantContactStatusLocalized", command.Id.Value.ToString());

		var localizedEnum = await Repository.Query<TenantContactStatusLocalized>()
			.FirstOrDefaultAsync(x => x.Id == command.Id && x.CultureCode == command.CultureCode, cancellationToken);
		EntityLocalizationNotFoundException.ThrowIfNull(localizedEnum, "TenantContactStatusLocalized",  command.Id.Value.ToString(), command.CultureCode.ToString());
		
		Repository.Delete(localizedEnum);

        await OnCompletedAsync(command, localizedEnum);
        await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}

public class DeleteTenantContactsStatusesTranslationsCommandValidator : AbstractValidator<DeleteTenantContactsStatusesTranslationsCommand>
{
	public DeleteTenantContactsStatusesTranslationsCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x.Value != noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName())
			.WithMessage($"{nameof(DeleteTenantContactsStatusesTranslationsCommand)} : {nameof(DeleteTenantContactsStatusesTranslationsCommand.CultureCode)} cannot be the default culture code: {noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName()}.");
			
    }
}