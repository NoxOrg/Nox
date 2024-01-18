// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateCurrencyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CurrencyKeyDto>;

internal partial class PartialUpdateCurrencyCommandHandler : PartialUpdateCurrencyCommandHandlerBase
{
	public PartialUpdateCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCurrencyCommandHandlerBase : CommandBase<PartialUpdateCurrencyCommand, CurrencyEntity>, IRequestHandler<PartialUpdateCurrencyCommand, CurrencyKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CurrencyKeyDto> Handle(PartialUpdateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.CurrencyMetadata.CreateId(request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CurrencyKeyDto(entity.Id.Value);
	}
}