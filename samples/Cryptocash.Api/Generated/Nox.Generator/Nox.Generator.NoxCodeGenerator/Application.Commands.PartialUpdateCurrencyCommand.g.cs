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
using Currency = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public record PartialUpdateCurrencyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CurrencyKeyDto?>;

public class PartialUpdateCurrencyCommandHandler: CommandBase<PartialUpdateCurrencyCommand, Currency>, IRequestHandler<PartialUpdateCurrencyCommand, CurrencyKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Currency> EntityMapper { get; }

	public PartialUpdateCurrencyCommandHandler(
		CryptocashDbContext dbContext,
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
		var keyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Currency>(), request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CurrencyKeyDto(entity.Id.Value);
	}
}