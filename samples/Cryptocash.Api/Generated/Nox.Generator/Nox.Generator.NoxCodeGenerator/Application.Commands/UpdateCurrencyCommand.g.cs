﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public partial record UpdateCurrencyCommand(System.String keyId, CurrencyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CurrencyKeyDto>;

internal partial class UpdateCurrencyCommandHandler : UpdateCurrencyCommandHandlerBase
{
	public UpdateCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCurrencyCommandHandlerBase : CommandBase<UpdateCurrencyCommand, CurrencyEntity>, IRequestHandler<UpdateCurrencyCommand, CurrencyKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> _entityFactory;
	protected UpdateCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CurrencyKeyDto> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.BankNotes).LoadAsync(cancellationToken);
		await DbContext.Entry(entity).Collection(x => x.ExchangeRates).LoadAsync(cancellationToken);

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new CurrencyKeyDto(entity.Id.Value);
	}
}

public class UpdateCurrencyValidator : AbstractValidator<UpdateCurrencyCommand>
{
    public UpdateCurrencyValidator()
    {
    }
}