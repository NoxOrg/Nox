// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public partial record DeleteStoreByIdCommand(IEnumerable<StoreKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteStoreByIdCommandHandler : DeleteStoreByIdCommandHandlerBase
{
	public DeleteStoreByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteStoreByIdCommandHandlerBase : CommandCollectionBase<DeleteStoreByIdCommand, StoreEntity>, IRequestHandler<DeleteStoreByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteStoreByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteStoreByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<StoreEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.StoreMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<StoreEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Store",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<StoreEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}