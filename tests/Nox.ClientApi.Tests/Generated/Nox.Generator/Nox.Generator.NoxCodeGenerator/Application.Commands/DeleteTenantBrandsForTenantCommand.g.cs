﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Commands;
public partial record DeleteTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, TenantBrandKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteTenantBrandsForTenantCommandHandler : DeleteTenantBrandsForTenantCommandHandlerBase
{
	public DeleteTenantBrandsForTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteTenantBrandsForTenantCommandHandlerBase : CommandBase<DeleteTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler <DeleteTenantBrandsForTenantCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTenantBrandsForTenantCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.TenantMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Tenants.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{keyId.ToString()}");
		}
		await DbContext.Entry(parentEntity).Collection(p => p.TenantBrands).LoadAsync(cancellationToken);
		var ownedId = ClientApi.Domain.TenantBrandMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.TenantBrands.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TenantBrand.TenantBrands",  $"{ownedId.ToString()}");
		}
		parentEntity.TenantBrands.Remove(entity);
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}

		return true;
	}
}