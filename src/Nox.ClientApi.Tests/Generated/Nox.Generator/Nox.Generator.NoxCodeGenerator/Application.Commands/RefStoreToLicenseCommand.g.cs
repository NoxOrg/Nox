
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

public abstract record RefStoreToLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefStoreToLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefStoreToLicenseCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreToLicenseCommandHandler
	: RefStoreToLicenseCommandHandlerBase<CreateRefStoreToLicenseCommand>
{
	public CreateRefStoreToLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreToLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefStoreToLicenseCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreToLicenseCommandHandler
	: RefStoreToLicenseCommandHandlerBase<DeleteRefStoreToLicenseCommand>
{
	public DeleteRefStoreToLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreToLicenseCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToLicenseCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreToLicenseCommandHandler
	: RefStoreToLicenseCommandHandlerBase<DeleteAllRefStoreToLicenseCommand>
{
	public DeleteAllRefStoreToLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreToLicenseCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToLicenseCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreToLicenseCommandHandlerBase(
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
				entity.CreateRefToLicense(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToLicense(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToLicense();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}