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
using TenantBrandLocalizedEntity = ClientApi.Domain.TenantBrandLocalized;

namespace ClientApi.Application.Commands;

public partial record  DeleteTenantBrandsTranslationsForTenantCommand(System.UInt32 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTenantBrandsTranslationsForTenantCommandHandler : DeleteTenantBrandsTranslationsForTenantCommandHandlerBase
{
    public DeleteTenantBrandsTranslationsForTenantCommandHandler(
           IRepository repository,
                  NoxSolution noxSolution) : base(repository, noxSolution)
    {
    }
}

internal abstract class DeleteTenantBrandsTranslationsForTenantCommandHandlerBase : CommandCollectionBase<DeleteTenantBrandsTranslationsForTenantCommand, TenantBrandLocalizedEntity>, IRequestHandler<DeleteTenantBrandsTranslationsForTenantCommand, bool>
{
    public IRepository Repository { get; }

    public DeleteTenantBrandsTranslationsForTenantCommandHandlerBase(
           IRepository repository,
           NoxSolution noxSolution) : base(noxSolution)
    {
        Repository = repository;
    }

    public virtual async Task<bool> Handle(DeleteTenantBrandsTranslationsForTenantCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
        
        var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(command.keyId));

        var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Tenant>(keys.ToArray(), p => p.TenantBrands,cancellationToken);
        EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant", "parentKeyId");
        var entityKeys = parentEntity.TenantBrands.Select(x => x.Id).ToList();
        var entities = await Repository.Query<TenantBrandLocalized>().Where(x => entityKeys.Contains(x.Id) && x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
        
        if (!entities.Any())
        {
            throw new EntityLocalizationNotFoundException("Tenant.TenantBrands",  String.Empty, command.CultureCode.ToString());
        }

        Repository.DeleteRange(entities);
        await OnCompletedAsync(command, entities);        
        
        await Repository.SaveChangesAsync(cancellationToken);
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