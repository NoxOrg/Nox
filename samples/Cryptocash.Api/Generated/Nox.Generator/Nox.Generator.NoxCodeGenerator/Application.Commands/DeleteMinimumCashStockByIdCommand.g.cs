// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public partial record DeleteMinimumCashStockByIdCommand(IEnumerable<MinimumCashStockKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteMinimumCashStockByIdCommandHandler : DeleteMinimumCashStockByIdCommandHandlerBase
{
	public DeleteMinimumCashStockByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteMinimumCashStockByIdCommandHandlerBase : CommandCollectionBase<DeleteMinimumCashStockByIdCommand, MinimumCashStockEntity>, IRequestHandler<DeleteMinimumCashStockByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteMinimumCashStockByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteMinimumCashStockByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<MinimumCashStockEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.MinimumCashStockMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("MinimumCashStock",  $"{keyId.ToString()}");
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