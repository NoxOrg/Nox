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
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public partial record DeleteCashStockOrderByIdCommand(IEnumerable<CashStockOrderKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCashStockOrderByIdCommandHandler : DeleteCashStockOrderByIdCommandHandlerBase
{
	public DeleteCashStockOrderByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCashStockOrderByIdCommandHandlerBase : CommandCollectionBase<DeleteCashStockOrderByIdCommand, CashStockOrderEntity>, IRequestHandler<DeleteCashStockOrderByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCashStockOrderByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCashStockOrderByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CashStockOrderEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.CashStockOrderMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<CashStockOrderEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("CashStockOrder",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<CashStockOrderEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}