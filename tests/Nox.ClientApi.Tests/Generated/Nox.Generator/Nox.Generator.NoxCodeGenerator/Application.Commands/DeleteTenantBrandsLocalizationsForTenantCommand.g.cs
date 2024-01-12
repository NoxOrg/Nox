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
using TenantBrandLocalizedEntity = ClientApi.Domain.TenantBrandLocalized;

namespace ClientApi.Application.Commands;

public partial record  DeleteTenantBrandsLocalizationsForTenantCommand(System.UInt32 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTenantBrandsLocalizationsForTenantCommandHandler : DeleteTenantBrandsLocalizationsForTenantCommandHandlerBase
{
    public DeleteTenantBrandsLocalizationsForTenantCommandHandler(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(dbContext, noxSolution)
    {
    }
}

internal abstract class DeleteTenantBrandsLocalizationsForTenantCommandHandlerBase : CommandCollectionBase<DeleteTenantBrandsLocalizationsForTenantCommand, TenantBrandLocalizedEntity>, IRequestHandler<DeleteTenantBrandsLocalizationsForTenantCommand, bool>
{
    public AppDbContext DbContext { get; }

    public DeleteTenantBrandsLocalizationsForTenantCommandHandlerBase(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        DbContext = dbContext;
    }

    public virtual async Task<bool> Handle(DeleteTenantBrandsLocalizationsForTenantCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
		var parentKeyId = ClientApi.Domain.TenantMetadata.CreateId(command.keyId);
        var parentEntity = await DbContext.Tenants.FindAsync(parentKeyId);

        if (parentEntity is null)
        {
            throw new EntityNotFoundException("Tenant", $"{parentKeyId.ToString()}");
        }

        await DbContext.Entry(parentEntity).Collection(p => p.TenantBrands).LoadAsync(cancellationToken);
                var entityKeys = parentEntity.TenantBrands.Select(x => x.Id).ToList();
                var entities = await DbContext.TenantBrandsLocalized.Where(x => entityKeys.Contains(x.Id) && x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
        
        if (!entities.Any())
        {
            throw new EntityNotFoundException("Tenant.TenantBrands",  String.Empty, command.CultureCode.ToString());
        }

        await OnCompletedAsync(command, entities);

        DbContext.RemoveRange(entities);
        

        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

public class DeleteTenantBrandsLocalizationsForTenantCommandValidator : AbstractValidator<DeleteTenantBrandsLocalizationsForTenantCommand>
{
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en_US");

    public DeleteTenantBrandsLocalizationsForTenantCommandValidator()
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x != _defaultCultureCode)
			.WithMessage($"{nameof(DeleteTenantBrandsLocalizationsForTenantCommand)} : {nameof(DeleteTenantBrandsLocalizationsForTenantCommand.CultureCode)} cannot be the default culture code: {_defaultCultureCode.Value}.");
			
    }
}