﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record DeleteAllTenantsForWorkplaceCommand(WorkplaceKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllTenantsForWorkplaceCommandHandler : DeleteAllTenantsForWorkplaceCommandHandlerBase
{
	public DeleteAllTenantsForWorkplaceCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllTenantsForWorkplaceCommandHandlerBase : CommandBase<DeleteAllTenantsForWorkplaceCommand, TenantEntity>, IRequestHandler <DeleteAllTenantsForWorkplaceCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllTenantsForWorkplaceCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllTenantsForWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.WorkplaceMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.Workplaces.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.Tenants;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{DbContext.Tenants.Remove(relatedEntity);
				await OnCompletedAsync(request, relatedEntity);
			}
			
			await trx.CommitAsync();
			
			var result = await DbContext.SaveChangesAsync(cancellationToken);
			if (result < 1)
			{
				return false;
			}

			return true;
		}
		catch
		{
			await trx.RollbackAsync();
			return false;
		}
	}
}