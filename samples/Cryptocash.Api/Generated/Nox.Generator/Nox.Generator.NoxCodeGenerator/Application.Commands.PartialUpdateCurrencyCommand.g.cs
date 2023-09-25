﻿﻿// Generated

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

internal class PartialUpdateCurrencyCommandHandler: PartialUpdateCurrencyCommandHandlerBase
{
	public PartialUpdateCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal class PartialUpdateCurrencyCommandHandlerBase: CommandBase<PartialUpdateCurrencyCommand, Currency>, IRequestHandler<PartialUpdateCurrencyCommand, CurrencyKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> EntityFactory { get; }

	public PartialUpdateCurrencyCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CurrencyKeyDto?> Handle(PartialUpdateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,Nox.Types.CurrencyCode3>("Id", request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CurrencyKeyDto(entity.Id.Value);
	}
}