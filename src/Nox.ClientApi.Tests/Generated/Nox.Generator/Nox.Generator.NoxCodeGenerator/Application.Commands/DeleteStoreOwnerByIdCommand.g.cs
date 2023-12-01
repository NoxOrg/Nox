// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public partial record DeleteStoreOwnerByIdCommand(IEnumerable<StoreOwnerKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteStoreOwnerByIdCommandHandler : DeleteStoreOwnerByIdCommandHandlerBase
{
	public DeleteStoreOwnerByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteStoreOwnerByIdCommandHandlerBase : CommandBase<DeleteStoreOwnerByIdCommand, StoreOwnerEntity>, IRequestHandler<DeleteStoreOwnerByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteStoreOwnerByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteStoreOwnerByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = ClientApi.Domain.StoreOwnerMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.StoreOwners.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new StoreOwnerEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}