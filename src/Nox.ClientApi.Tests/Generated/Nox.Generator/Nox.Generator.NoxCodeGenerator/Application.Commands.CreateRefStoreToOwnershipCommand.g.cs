
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

public record CreateRefStoreToOwnershipCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefStoreToOwnershipCommandHandler: CreateRefStoreToOwnershipCommandHandlerBase
{
	public CreateRefStoreToOwnershipCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider)
	{ }
}

public abstract class CreateRefStoreToOwnershipCommandHandlerBase: CommandBase<CreateRefStoreToOwnershipCommand, Store>, 
	IRequestHandler <CreateRefStoreToOwnershipCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public CreateRefStoreToOwnershipCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(CreateRefStoreToOwnershipCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<StoreOwner, Nox.Types.Text>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.StoreOwners.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToStoreOwnerOwnership(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}