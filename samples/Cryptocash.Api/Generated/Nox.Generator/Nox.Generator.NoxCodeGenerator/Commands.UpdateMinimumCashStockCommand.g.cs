﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record UpdateMinimumCashStockCommand(System.Int64 keyId, MinimumCashStockUpdateDto EntityDto) : IRequest<MinimumCashStockKeyDto?>;

public class UpdateMinimumCashStockCommandHandler: CommandBase<UpdateMinimumCashStockCommand, MinimumCashStock>, IRequestHandler<UpdateMinimumCashStockCommand, MinimumCashStockKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<MinimumCashStock> EntityMapper { get; }

	public UpdateMinimumCashStockCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<MinimumCashStock> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<MinimumCashStockKeyDto?> Handle(UpdateMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<MinimumCashStock,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<MinimumCashStock>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new MinimumCashStockKeyDto(entity.Id.Value);
	}
}