﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public record UpdateMinimumCashStockCommand(System.Int64 keyId, MinimumCashStockUpdateDto EntityDto, System.Guid? Etag) : IRequest<MinimumCashStockKeyDto?>;

internal partial class UpdateMinimumCashStockCommandHandler : UpdateMinimumCashStockCommandHandlerBase
{
	public UpdateMinimumCashStockCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateMinimumCashStockCommandHandlerBase : CommandBase<UpdateMinimumCashStockCommand, MinimumCashStockEntity>, IRequestHandler<UpdateMinimumCashStockCommand, MinimumCashStockKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> _entityFactory;

	public UpdateMinimumCashStockCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<MinimumCashStockKeyDto?> Handle(UpdateMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(request.keyId);

		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new MinimumCashStockKeyDto(entity.Id.Value);
	}
}