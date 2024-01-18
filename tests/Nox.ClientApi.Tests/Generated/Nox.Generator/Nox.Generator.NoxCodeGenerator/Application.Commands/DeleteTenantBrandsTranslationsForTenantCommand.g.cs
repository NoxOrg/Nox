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

public partial record  DeleteTenantBrandsTranslationsForTenantCommand(System.UInt32 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTenantBrandsTranslationsForTenantCommandHandler : DeleteTenantBrandsTranslationsForTenantCommandHandlerBase
{
    public DeleteTenantBrandsTranslationsForTenantCommandHandler(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(dbContext, noxSolution)
    {
    }
}

internal abstract class DeleteTenantBrandsTranslationsForTenantCommandHandlerBase : CommandCollectionBase<DeleteTenantBrandsTranslationsForTenantCommand, TenantBrandLocalizedEntity>, IRequestHandler<DeleteTenantBrandsTranslationsForTenantCommand, bool>
{
    public AppDbContext DbContext { get; }

    public DeleteTenantBrandsTranslationsForTenantCommandHandlerBase(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        DbContext = dbContext;
    }

    public virtual async Task<bool> Handle(DeleteTenantBrandsTranslationsForTenantCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
		var parentKeyId = Dto.TenantMetadata.CreateId(command.keyId);
        var parentEntity = await DbContext.Tenants.FindAsync(parentKeyId);

        EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant", $"{parentKeyId.ToString()}");

        await DbContext.Entry(parentEntity).Collection(p => p.TenantBrands).LoadAsync(cancellationToken);
                var entityKeys = parentEntity.TenantBrands.Select(x => x.Id).ToList();
                var entities = await DbContext.TenantBrandsLocalized.Where(x => entityKeys.Contains(x.Id) && x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
        
        if (!entities.Any())
        {
            throw new EntityLocalizationNotFoundException("Tenant.TenantBrands",  String.Empty, command.CultureCode.ToString());
        }

        await OnCompletedAsync(command, entities);

        DbContext.RemoveRange(entities);
        

        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

public class DeleteTenantBrandsTranslationsForTenantCommandValidator : AbstractValidator<DeleteTenantBrandsTranslationsForTenantCommand>
{
    public DeleteTenantBrandsTranslationsForTenantCommandValidator(NoxSolution noxSolution)
    {
        var defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);

		RuleFor(x => x.CultureCode)
			.Must(x => x != defaultCultureCode)
			.WithMessage($"{nameof(DeleteTenantBrandsTranslationsForTenantCommand)} : {nameof(DeleteTenantBrandsTranslationsForTenantCommand.CultureCode)} cannot be the default culture code: {defaultCultureCode.Value}.");
			
    }
}