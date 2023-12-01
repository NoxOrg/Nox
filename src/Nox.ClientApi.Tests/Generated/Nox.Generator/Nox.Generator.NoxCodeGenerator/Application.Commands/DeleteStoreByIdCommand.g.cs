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
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public partial record DeleteStoreByIdCommand(IEnumerable<StoreKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteStoreByIdCommandHandler : DeleteStoreByIdCommandHandlerBase
{
	public DeleteStoreByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteStoreByIdCommandHandlerBase : CommandBase<DeleteStoreByIdCommand, StoreEntity>, IRequestHandler<DeleteStoreByIdCommand, bool>
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
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = ClientApi.Domain.StoreMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Stores.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new StoreEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}