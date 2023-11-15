
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

public abstract record RefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto, WorkplaceKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefTenantToWorkplacesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<CreateRefTenantToWorkplacesCommand>
{
	public CreateRefTenantToWorkplacesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefTenantToWorkplacesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<DeleteRefTenantToWorkplacesCommand>
{
	public DeleteRefTenantToWorkplacesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto)
	: RefTenantToWorkplacesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<DeleteAllRefTenantToWorkplacesCommand>
{
	public DeleteAllRefTenantToWorkplacesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTenantToWorkplacesCommandHandlerBase<TRequest> : CommandBase<TRequest, TenantEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTenantToWorkplacesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTenantToWorkplacesCommandHandlerBase(
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
		var keyId = ClientApi.Domain.TenantMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Tenants.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		ClientApi.Domain.Workplace? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = ClientApi.Domain.WorkplaceMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Workplaces.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToWorkplaces(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToWorkplaces(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.Workplaces).LoadAsync();
				entity.DeleteAllRefToWorkplaces();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}