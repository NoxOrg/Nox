
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

public abstract record RefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto, TenantKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto, TenantKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToTenantsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<CreateRefWorkplaceToTenantsCommand>
{
	public CreateRefWorkplaceToTenantsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto, TenantKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToTenantsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<DeleteRefWorkplaceToTenantsCommand>
{
	public DeleteRefWorkplaceToTenantsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto)
	: RefWorkplaceToTenantsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<DeleteAllRefWorkplaceToTenantsCommand>
{
	public DeleteAllRefWorkplaceToTenantsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefWorkplaceToTenantsCommandHandlerBase<TRequest> : CommandBase<TRequest, WorkplaceEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefWorkplaceToTenantsCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefWorkplaceToTenantsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.WorkplaceMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		ClientApi.Domain.Tenant? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = ClientApi.Domain.TenantMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Tenants.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTenants(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTenants(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.Tenants).LoadAsync();
				entity.DeleteAllRefToTenants();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}