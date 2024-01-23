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
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public partial record DeleteStoreOwnerByIdCommand(IEnumerable<StoreOwnerKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteStoreOwnerByIdCommandHandler : DeleteStoreOwnerByIdCommandHandlerBase
{
	public DeleteStoreOwnerByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteStoreOwnerByIdCommandHandlerBase : CommandCollectionBase<DeleteStoreOwnerByIdCommand, StoreOwnerEntity>, IRequestHandler<DeleteStoreOwnerByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteStoreOwnerByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteStoreOwnerByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<StoreOwnerEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.StoreOwnerMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<StoreOwner>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("StoreOwner",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<StoreOwnerEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}