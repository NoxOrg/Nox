// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public partial record DeleteMinimumCashStockByIdCommand(IEnumerable<MinimumCashStockKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteMinimumCashStockByIdCommandHandler : DeleteMinimumCashStockByIdCommandHandlerBase
{
	public DeleteMinimumCashStockByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteMinimumCashStockByIdCommandHandlerBase : CommandCollectionBase<DeleteMinimumCashStockByIdCommand, MinimumCashStockEntity>, IRequestHandler<DeleteMinimumCashStockByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteMinimumCashStockByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
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

			var entity = await Repository.FindAsync<MinimumCashStockEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("MinimumCashStock",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<MinimumCashStockEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}