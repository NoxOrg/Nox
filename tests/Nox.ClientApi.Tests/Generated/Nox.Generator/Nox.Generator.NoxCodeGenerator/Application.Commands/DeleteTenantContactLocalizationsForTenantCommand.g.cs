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

public partial record  DeleteTenantContactLocalizationsForTenantCommand(System.UInt32 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTenantContactLocalizationsForTenantCommandHandler : DeleteTenantContactLocalizationsForTenantCommandHandlerBase
{
    public DeleteTenantContactLocalizationsForTenantCommandHandler(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(dbContext, noxSolution)
    {
    }
}

internal abstract class DeleteTenantContactLocalizationsForTenantCommandHandlerBase : CommandBase<DeleteTenantContactLocalizationsForTenantCommand, TenantContactLocalizedEntity>, IRequestHandler<DeleteTenantContactLocalizationsForTenantCommand, bool>
{
    public AppDbContext DbContext { get; }

    public DeleteTenantContactLocalizationsForTenantCommandHandlerBase(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        DbContext = dbContext;
    }

    public virtual async Task<bool> Handle(DeleteTenantContactLocalizationsForTenantCommand command, CancellationToken cancellationToken)
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

public class DeleteTenantContactLocalizationsForTenantCommandValidator : AbstractValidator<DeleteTenantContactLocalizationsForTenantCommand>
{
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public DeleteTenantContactLocalizationsForTenantCommandValidator()
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x != _defaultCultureCode)
			.WithMessage($"{nameof(DeleteTenantContactLocalizationsForTenantCommand)} : {nameof(DeleteTenantContactLocalizationsForTenantCommand.CultureCode)} cannot be the default culture code: {_defaultCultureCode.Value}.");
			
    }
}