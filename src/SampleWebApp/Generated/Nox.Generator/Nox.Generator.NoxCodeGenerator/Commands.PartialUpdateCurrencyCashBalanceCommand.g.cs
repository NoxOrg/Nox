﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;

public record PartialUpdateCurrencyCashBalanceCommand(System.String keyStoreId, System.UInt32 keyCurrencyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CurrencyCashBalanceKeyDto?>;

public class PartialUpdateCurrencyCashBalanceCommandHandler: CommandBase<PartialUpdateCurrencyCashBalanceCommand, CurrencyCashBalance>, IRequestHandler<PartialUpdateCurrencyCashBalanceCommand, CurrencyCashBalanceKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<CurrencyCashBalance> EntityMapper { get; }

	public PartialUpdateCurrencyCashBalanceCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CurrencyCashBalance> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CurrencyCashBalanceKeyDto?> Handle(PartialUpdateCurrencyCashBalanceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyStoreId = CreateNoxTypeForKey<CurrencyCashBalance,Text>("StoreId", request.keyStoreId);
		var keyCurrencyId = CreateNoxTypeForKey<CurrencyCashBalance,Nuid>("CurrencyId", request.keyCurrencyId);

		var entity = await DbContext.CurrencyCashBalances.FindAsync(keyStoreId, keyCurrencyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CurrencyCashBalance>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CurrencyCashBalanceKeyDto(entity.StoreId.Value, entity.CurrencyId.Value);
	}
}