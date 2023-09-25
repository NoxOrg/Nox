﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using MinimumCashStock = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public record PartialUpdateMinimumCashStockCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <MinimumCashStockKeyDto?>;

internal class PartialUpdateMinimumCashStockCommandHandler: PartialUpdateMinimumCashStockCommandHandlerBase
{
	public PartialUpdateMinimumCashStockCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal class PartialUpdateMinimumCashStockCommandHandlerBase: CommandBase<PartialUpdateMinimumCashStockCommand, MinimumCashStock>, IRequestHandler<PartialUpdateMinimumCashStockCommand, MinimumCashStockKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> EntityFactory { get; }

	public PartialUpdateMinimumCashStockCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<MinimumCashStockKeyDto?> Handle(PartialUpdateMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<MinimumCashStock,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new MinimumCashStockKeyDto(entity.Id.Value);
	}
}