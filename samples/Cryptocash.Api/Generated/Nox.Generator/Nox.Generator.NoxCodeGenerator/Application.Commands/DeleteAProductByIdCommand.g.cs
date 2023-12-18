// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using AProductEntity = Cryptocash.Domain.AProduct;

namespace Cryptocash.Application.Commands;

public partial record DeleteAProductByIdCommand(IEnumerable<AProductKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteAProductByIdCommandHandler : DeleteAProductByIdCommandHandlerBase
{
	public DeleteAProductByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteAProductByIdCommandHandlerBase : CommandCollectionBase<DeleteAProductByIdCommand, AProductEntity>, IRequestHandler<DeleteAProductByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAProductByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAProductByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<AProductEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Cryptocash.Domain.AProductMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.AProducts.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
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