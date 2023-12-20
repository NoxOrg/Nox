﻿
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public abstract record RefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto, TenantKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToTenantsCommand(EntityKeyDto);

internal partial class CreateRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<CreateRefWorkplaceToTenantsCommand>
{
	public CreateRefWorkplaceToTenantsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefWorkplaceToTenantsCommand request)
    {
		var entity = await GetWorkplace(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTenant(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToTenants(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto, List<TenantKeyDto> RelatedEntitiesKeysDtos)
	: RefWorkplaceToTenantsCommand(EntityKeyDto);

internal partial class UpdateRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<UpdateRefWorkplaceToTenantsCommand>
{
	public UpdateRefWorkplaceToTenantsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefWorkplaceToTenantsCommand request)
    {
		var entity = await GetWorkplace(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<ClientApi.Domain.Tenant>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTenant(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Tenants).LoadAsync();
		entity.UpdateRefToTenants(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto, TenantKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToTenantsCommand(EntityKeyDto);

internal partial class DeleteRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<DeleteRefWorkplaceToTenantsCommand>
{
	public DeleteRefWorkplaceToTenantsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefWorkplaceToTenantsCommand request)
    {
        var entity = await GetWorkplace(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTenant(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToTenants(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto)
	: RefWorkplaceToTenantsCommand(EntityKeyDto);

internal partial class DeleteAllRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<DeleteAllRefWorkplaceToTenantsCommand>
{
	public DeleteAllRefWorkplaceToTenantsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefWorkplaceToTenantsCommand request)
    {
        var entity = await GetWorkplace(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.Tenants).LoadAsync();
		entity.DeleteAllRefToTenants();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefWorkplaceToTenantsCommandHandlerBase<TRequest> : CommandBase<TRequest, WorkplaceEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefWorkplaceToTenantsCommand
{
	public AppDbContext DbContext { get; }

	public RefWorkplaceToTenantsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<WorkplaceEntity?> GetWorkplace(WorkplaceKeyDto entityKeyDto)
	{
		var keyId = ClientApi.Domain.WorkplaceMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Workplaces.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Tenant?> GetTenant(TenantKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.TenantMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Tenants.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, WorkplaceEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}