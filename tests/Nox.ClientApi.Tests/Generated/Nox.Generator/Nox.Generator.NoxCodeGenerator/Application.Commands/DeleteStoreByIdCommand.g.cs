// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public partial record DeleteStoreByIdCommand(IEnumerable<StoreKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteStoreByIdCommandHandler : DeleteStoreByIdCommandHandlerBase
{
	public DeleteStoreByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteStoreByIdCommandHandlerBase : CommandCollectionBase<DeleteStoreByIdCommand, StoreEntity>, IRequestHandler<DeleteStoreByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteStoreByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteStoreByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<StoreEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = ClientApi.Domain.StoreMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Stores.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Store",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}