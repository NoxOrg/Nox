﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Currency = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public record UpdateCurrencyCommand(System.String keyId, CurrencyUpdateDto EntityDto, System.Guid? Etag) : IRequest<CurrencyKeyDto?>;

public partial class UpdateCurrencyCommandHandler: UpdateCurrencyCommandHandlerBase
{
	public UpdateCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

public abstract class UpdateCurrencyCommandHandlerBase: CommandBase<UpdateCurrencyCommand, Currency>, IRequestHandler<UpdateCurrencyCommand, CurrencyKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> _entityFactory;

	public UpdateCurrencyCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CurrencyKeyDto?> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,Nox.Types.CurrencyCode3>("Id", request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CurrencyKeyDto(entity.Id.Value);
	}
}