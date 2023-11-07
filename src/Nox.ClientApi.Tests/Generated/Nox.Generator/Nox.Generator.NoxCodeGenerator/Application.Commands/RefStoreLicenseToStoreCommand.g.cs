
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
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public abstract record RefStoreLicenseToStoreCommand(StoreLicenseKeyDto EntityKeyDto, StoreKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefStoreLicenseToStoreCommand(StoreLicenseKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToStoreCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreLicenseToStoreCommandHandler
	: RefStoreLicenseToStoreCommandHandlerBase<CreateRefStoreLicenseToStoreCommand>
{
	public CreateRefStoreLicenseToStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreLicenseToStoreCommand(StoreLicenseKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToStoreCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreLicenseToStoreCommandHandler
	: RefStoreLicenseToStoreCommandHandlerBase<DeleteRefStoreLicenseToStoreCommand>
{
	public DeleteRefStoreLicenseToStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreLicenseToStoreCommand(StoreLicenseKeyDto EntityKeyDto)
	: RefStoreLicenseToStoreCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreLicenseToStoreCommandHandler
	: RefStoreLicenseToStoreCommandHandlerBase<DeleteAllRefStoreLicenseToStoreCommand>
{
	public DeleteAllRefStoreLicenseToStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreLicenseToStoreCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreLicenseEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreLicenseToStoreCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreLicenseToStoreCommandHandlerBase(
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
		var keyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.StoreLicenses.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		ClientApi.Domain.Store? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = ClientApi.Domain.StoreMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Stores.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToStore(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToStore(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToStore();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}