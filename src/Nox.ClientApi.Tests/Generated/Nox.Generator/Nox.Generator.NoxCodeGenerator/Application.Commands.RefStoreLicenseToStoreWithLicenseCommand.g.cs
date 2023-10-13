
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

public abstract record RefStoreLicenseToStoreWithLicenseCommand(StoreLicenseKeyDto EntityKeyDto, StoreKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefStoreLicenseToStoreWithLicenseCommand(StoreLicenseKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToStoreWithLicenseCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreLicenseToStoreWithLicenseCommandHandler
	: RefStoreLicenseToStoreWithLicenseCommandHandlerBase<CreateRefStoreLicenseToStoreWithLicenseCommand>
{
	public CreateRefStoreLicenseToStoreWithLicenseCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreLicenseToStoreWithLicenseCommand(StoreLicenseKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToStoreWithLicenseCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreLicenseToStoreWithLicenseCommandHandler
	: RefStoreLicenseToStoreWithLicenseCommandHandlerBase<DeleteRefStoreLicenseToStoreWithLicenseCommand>
{
	public DeleteRefStoreLicenseToStoreWithLicenseCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreLicenseToStoreWithLicenseCommand(StoreLicenseKeyDto EntityKeyDto)
	: RefStoreLicenseToStoreWithLicenseCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreLicenseToStoreWithLicenseCommandHandler
	: RefStoreLicenseToStoreWithLicenseCommandHandlerBase<DeleteAllRefStoreLicenseToStoreWithLicenseCommand>
{
	public DeleteAllRefStoreLicenseToStoreWithLicenseCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreLicenseToStoreWithLicenseCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreLicenseEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreLicenseToStoreWithLicenseCommand
{
	public ClientApiDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreLicenseToStoreWithLicenseCommandHandlerBase(
		ClientApiDbContext dbContext,
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
		OnExecuting(request);
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
				entity.CreateRefToStoreWithLicense(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToStoreWithLicense(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToStoreWithLicense();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}