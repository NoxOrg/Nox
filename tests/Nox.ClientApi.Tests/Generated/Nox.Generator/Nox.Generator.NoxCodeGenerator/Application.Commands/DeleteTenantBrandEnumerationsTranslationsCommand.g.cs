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
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Commands;
public partial record  DeleteTenantBrandsStatusesTranslationsCommand(Enumeration Id, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTenantBrandsStatusesTranslationsCommandHandler : DeleteTenantBrandsStatusesTranslationsCommandHandlerBase
{
	public DeleteTenantBrandsStatusesTranslationsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTenantBrandsStatusesTranslationsCommandHandlerBase : CommandBase<DeleteTenantBrandsStatusesTranslationsCommand, TenantBrandStatusLocalized>, IRequestHandler<DeleteTenantBrandsStatusesTranslationsCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTenantBrandsStatusesTranslationsCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTenantBrandsStatusesTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var enumEntity = await Repository.FindAsync<TenantBrandStatus>(command.Id, cancellationToken);
        EntityNotFoundException.ThrowIfNull(enumEntity, "TenantBrandStatusLocalized", command.Id.Value.ToString());

		var localizedEnum = await Repository.Query<TenantBrandStatusLocalized>()
			.FirstOrDefaultAsync(x => x.Id == command.Id && x.CultureCode == command.CultureCode, cancellationToken);
		EntityLocalizationNotFoundException.ThrowIfNull(localizedEnum, "TenantBrandStatusLocalized",  command.Id.Value.ToString(), command.CultureCode.ToString());
		
		Repository.Delete(localizedEnum);

        await OnCompletedAsync(command, localizedEnum);
        await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}

public class DeleteTenantBrandsStatusesTranslationsCommandValidator : AbstractValidator<DeleteTenantBrandsStatusesTranslationsCommand>
{
	public DeleteTenantBrandsStatusesTranslationsCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x.Value != noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName())
			.WithMessage($"{nameof(DeleteTenantBrandsStatusesTranslationsCommand)} : {nameof(DeleteTenantBrandsStatusesTranslationsCommand.CultureCode)} cannot be the default culture code: {noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName()}.");
			
    }
}