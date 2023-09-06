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
using Currency = SampleWebApp.Domain.Currency;

namespace SampleWebApp.Application.Commands;

public record PartialUpdateCurrencyCommand(System.UInt32 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CurrencyKeyDto?>;

public class PartialUpdateCurrencyCommandHandler: CommandBase<PartialUpdateCurrencyCommand, Currency>, IRequestHandler<PartialUpdateCurrencyCommand, CurrencyKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<Currency> EntityMapper { get; }

	public PartialUpdateCurrencyCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Currency> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CurrencyKeyDto?> Handle(PartialUpdateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,Nuid>("Id", request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Currency>(), request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CurrencyKeyDto(entity.Id.Value);
	}
}