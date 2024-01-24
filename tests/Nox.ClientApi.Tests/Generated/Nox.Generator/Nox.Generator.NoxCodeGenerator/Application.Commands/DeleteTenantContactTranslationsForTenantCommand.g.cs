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
using Nox.Extensions;

using ClientApi.Domain;
using TenantContactLocalizedEntity = ClientApi.Domain.TenantContactLocalized;

namespace ClientApi.Application.Commands;

public partial record  DeleteTenantContactTranslationsForTenantCommand(System.UInt32 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTenantContactTranslationsForTenantCommandHandler : DeleteTenantContactTranslationsForTenantCommandHandlerBase
{
    public DeleteTenantContactTranslationsForTenantCommandHandler(
           IRepository repository,
                  NoxSolution noxSolution) : base(repository, noxSolution)
    {
    }
}

internal abstract class DeleteTenantContactTranslationsForTenantCommandHandlerBase : CommandBase<DeleteTenantContactTranslationsForTenantCommand, TenantContactLocalizedEntity>, IRequestHandler<DeleteTenantContactTranslationsForTenantCommand, bool>
{
    public IRepository Repository { get; }

    public DeleteTenantContactTranslationsForTenantCommandHandlerBase(
           IRepository repository,
           NoxSolution noxSolution) : base(noxSolution)
    {
        Repository = repository;
    }

    public virtual async Task<bool> Handle(DeleteTenantContactTranslationsForTenantCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
        
        var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(command.keyId));

        var parentEntity = await Repository.FindAsync<Tenant>(keys.ToArray(), cancellationToken);
        EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant", "parentKeyId");

        var entity = await Repository.Query<TenantContactLocalized>().SingleOrDefaultAsync(x => x.TenantId == parentEntity.Id && x.CultureCode == command.CultureCode, cancellationToken);
        EntityLocalizationNotFoundException.ThrowIfNull(entity, "Tenant.TenantContact", String.Empty, command.CultureCode.ToString());        
        Repository.Delete(entity);
        await OnCompletedAsync(command, entity);

        await Repository.SaveChangesAsync(cancellationToken);
        return true;
    }
}

public class DeleteTenantContactTranslationsForTenantCommandValidator : AbstractValidator<DeleteTenantContactTranslationsForTenantCommand>
{
    public DeleteTenantContactTranslationsForTenantCommandValidator(NoxSolution noxSolution)
    {
        var defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);

		RuleFor(x => x.CultureCode)
			.Must(x => x != defaultCultureCode)
			.WithMessage($"{nameof(DeleteTenantContactTranslationsForTenantCommand)} : {nameof(DeleteTenantContactTranslationsForTenantCommand.CultureCode)} cannot be the default culture code: {defaultCultureCode.Value}.");
			
    }
}