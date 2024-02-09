// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateCashStockOrderCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CashStockOrderKeyDto>;

internal partial class PartialUpdateCashStockOrderCommandHandler : PartialUpdateCashStockOrderCommandHandlerBase
{
	public PartialUpdateCashStockOrderCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCashStockOrderCommandHandlerBase : CommandBase<PartialUpdateCashStockOrderCommand, CashStockOrderEntity>, IRequestHandler<PartialUpdateCashStockOrderCommand, CashStockOrderKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCashStockOrderCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CashStockOrderKeyDto> Handle(PartialUpdateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.CashStockOrderMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Cryptocash.Domain.CashStockOrder>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new CashStockOrderKeyDto(entity.Id.Value);
	}
}