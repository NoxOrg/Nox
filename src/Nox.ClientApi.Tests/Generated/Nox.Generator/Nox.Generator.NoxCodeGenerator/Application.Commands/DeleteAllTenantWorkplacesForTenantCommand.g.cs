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
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public partial record DeleteAllWorkplacesForTenantCommand(TenantKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllWorkplacesForTenantCommandHandler : DeleteAllWorkplacesForTenantCommandHandlerBase
{
	public DeleteAllWorkplacesForTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllWorkplacesForTenantCommandHandlerBase : CommandBase<DeleteAllWorkplacesForTenantCommand, WorkplaceEntity>, IRequestHandler <DeleteAllWorkplacesForTenantCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllWorkplacesForTenantCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllWorkplacesForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.TenantMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.Tenants.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.Workplaces;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{DbContext.Workplaces.Remove(relatedEntity);
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