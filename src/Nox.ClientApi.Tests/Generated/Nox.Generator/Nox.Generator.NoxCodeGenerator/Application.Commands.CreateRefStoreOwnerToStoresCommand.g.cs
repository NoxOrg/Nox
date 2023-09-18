
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
public record CreateRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefStoreOwnerToStoresCommandHandler: CommandBase<CreateRefStoreOwnerToStoresCommand, StoreOwner>, 
	IRequestHandler <CreateRefStoreOwnerToStoresCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public CreateRefStoreOwnerToStoresCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefStoreOwnerToStoresCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<StoreOwner, Nox.Types.Text>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Store, Nox.Types.Guid>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Stores.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToStoreStores(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}