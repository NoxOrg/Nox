// Generated

#nullable enable
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using Nox.Extensions;
using System.CodeDom;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using TenantContactLocalizedEntity = ClientApi.Domain.TenantContactLocalized;

namespace ClientApi.Application.Commands;

public partial record  DeleteTenantContactTranslationsForTenantCommand(System.UInt32 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTenantContactTranslationsForTenantCommandHandler : DeleteTenantContactTranslationsForTenantCommandHandlerBase
{
    public DeleteTenantContactTranslationsForTenantCommandHandler(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(dbContext, noxSolution)
    {
    }
}

internal abstract class DeleteTenantContactTranslationsForTenantCommandHandlerBase : CommandBase<DeleteTenantContactTranslationsForTenantCommand, TenantContactLocalizedEntity>, IRequestHandler<DeleteTenantContactTranslationsForTenantCommand, bool>
{
    public AppDbContext DbContext { get; }

    public DeleteTenantContactTranslationsForTenantCommandHandlerBase(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        DbContext = dbContext;
    }

    public virtual async Task<bool> Handle(DeleteTenantContactTranslationsForTenantCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
		var parentKeyId = ClientApi.Domain.TenantMetadata.CreateId(command.keyId);
        var parentEntity = await DbContext.Tenants.FindAsync(parentKeyId);

        if (parentEntity is null)
        {
            throw new EntityNotFoundException("Tenant", $"{parentKeyId.ToString()}");
        }

        var entity = await DbContext.TenantContactsLocalized.SingleOrDefaultAsync(x => x.TenantId == parentEntity.Id && x.CultureCode == command.CultureCode, cancellationToken);
        if (entity is null)
        {
            throw new EntityNotFoundException("Tenant.TenantContact",  String.Empty, command.CultureCode.ToString());
        }

        await OnCompletedAsync(command, entity);

        DbContext.Remove(entity);


        await DbContext.SaveChangesAsync(cancellationToken);
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