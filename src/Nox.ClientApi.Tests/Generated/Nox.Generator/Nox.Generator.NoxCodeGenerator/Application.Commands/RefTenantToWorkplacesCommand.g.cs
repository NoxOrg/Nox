
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
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public abstract record RefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefTenantToWorkplacesCommand(EntityKeyDto);

internal partial class CreateRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<CreateRefTenantToWorkplacesCommand>
{
	public CreateRefTenantToWorkplacesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTenantToWorkplacesCommand request)
    {
		var entity = await GetTenant(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetWorkplace(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToWorkplaces(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto, List<WorkplaceKeyDto> RelatedEntitiesKeysDtos)
	: RefTenantToWorkplacesCommand(EntityKeyDto);

internal partial class UpdateRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<UpdateRefTenantToWorkplacesCommand>
{
	public UpdateRefTenantToWorkplacesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTenantToWorkplacesCommand request)
    {
		var entity = await GetTenant(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<ClientApi.Domain.Workplace>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetWorkplace(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Workplaces).LoadAsync();
		entity.UpdateRefToWorkplaces(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefTenantToWorkplacesCommand(EntityKeyDto);

internal partial class DeleteRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<DeleteRefTenantToWorkplacesCommand>
{
	public DeleteRefTenantToWorkplacesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTenantToWorkplacesCommand request)
    {
        var entity = await GetTenant(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetWorkplace(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToWorkplaces(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto)
	: RefTenantToWorkplacesCommand(EntityKeyDto);

internal partial class DeleteAllRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<DeleteAllRefTenantToWorkplacesCommand>
{
	public DeleteAllRefTenantToWorkplacesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTenantToWorkplacesCommand request)
    {
        var entity = await GetTenant(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.Workplaces).LoadAsync();
		entity.DeleteAllRefToWorkplaces();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTenantToWorkplacesCommandHandlerBase<TRequest> : CommandBase<TRequest, TenantEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTenantToWorkplacesCommand
{
	public AppDbContext DbContext { get; }

	public RefTenantToWorkplacesCommandHandlerBase(
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

	protected async Task<TenantEntity?> GetTenant(TenantKeyDto entityKeyDto)
	{
		var keyId = ClientApi.Domain.TenantMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Tenants.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Workplace?> GetWorkplace(WorkplaceKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.WorkplaceMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Workplaces.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TenantEntity entity)
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