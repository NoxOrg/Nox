
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;

public abstract record RefStoreToLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefStoreToLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefStoreToLicenseCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreToLicenseCommandHandler
	: RefStoreToLicenseCommandHandlerBase<CreateRefStoreToLicenseCommand>
{
	public CreateRefStoreToLicenseCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreToLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefStoreToLicenseCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreToLicenseCommandHandler
	: RefStoreToLicenseCommandHandlerBase<DeleteRefStoreToLicenseCommand>
{
	public DeleteRefStoreToLicenseCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreToLicenseCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToLicenseCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreToLicenseCommandHandler
	: RefStoreToLicenseCommandHandlerBase<DeleteAllRefStoreToLicenseCommand>
{
	public DeleteAllRefStoreToLicenseCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreToLicenseCommandHandlerBase<TRequest>: CommandBase<TRequest, Store>, 
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToLicenseCommand
{
	public ClientApiDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreToLicenseCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		StoreLicense? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<StoreLicense, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
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

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}