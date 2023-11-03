
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
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public abstract record RefStoreToStoreLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefStoreToStoreLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefStoreToStoreLicenseCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreToStoreLicenseCommandHandler
	: RefStoreToStoreLicenseCommandHandlerBase<CreateRefStoreToStoreLicenseCommand>
{
	public CreateRefStoreToStoreLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreToStoreLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefStoreToStoreLicenseCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreToStoreLicenseCommandHandler
	: RefStoreToStoreLicenseCommandHandlerBase<DeleteRefStoreToStoreLicenseCommand>
{
	public DeleteRefStoreToStoreLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreToStoreLicenseCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToStoreLicenseCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreToStoreLicenseCommandHandler
	: RefStoreToStoreLicenseCommandHandlerBase<DeleteAllRefStoreToStoreLicenseCommand>
{
	public DeleteAllRefStoreToStoreLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreToStoreLicenseCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToStoreLicenseCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreToStoreLicenseCommandHandlerBase(
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
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		ClientApi.Domain.StoreLicense? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.StoreLicenses.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToStoreLicense(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToStoreLicense(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToStoreLicense();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}