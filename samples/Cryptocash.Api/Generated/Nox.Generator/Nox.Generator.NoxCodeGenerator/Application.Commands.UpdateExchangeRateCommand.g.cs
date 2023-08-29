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

public record UpdateExchangeRateCommand(System.Int64 keyId, ExchangeRateUpdateDto EntityDto) : IRequest<ExchangeRateKeyDto?>;

public class UpdateExchangeRateCommandHandler: CommandBase<UpdateExchangeRateCommand, ExchangeRate>, IRequestHandler<UpdateExchangeRateCommand, ExchangeRateKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<ExchangeRate> EntityMapper { get; }

	public UpdateExchangeRateCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ExchangeRate> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<ExchangeRateKeyDto?> Handle(UpdateExchangeRateCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<ExchangeRate,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.ExchangeRates.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<ExchangeRate>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new ExchangeRateKeyDto(entity.Id.Value);
	}
}