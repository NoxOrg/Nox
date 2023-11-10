﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CurrencyEntity = ClientApi.Domain.Currency;

namespace ClientApi.Application.Commands;

public record UpdateCurrencyCommand(System.String keyId, CurrencyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CurrencyKeyDto?>;

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

internal abstract class UpdateCurrencyCommandHandlerBase : CommandBase<UpdateCurrencyCommand, CurrencyEntity>, IRequestHandler<UpdateCurrencyCommand, CurrencyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> _entityFactory;

	public UpdateCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CurrencyKeyDto?> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.CurrencyMetadata.CreateId(request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.StoreLicenseDefault).LoadAsync();
		var storeLicenseDefaultEntities = new List<ClientApi.Domain.StoreLicense>();
		foreach(var relatedEntityId in request.EntityDto.StoreLicenseDefaultId)
		{
			var relatedKey = ClientApi.Domain.StoreLicenseMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.StoreLicenses.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				storeLicenseDefaultEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("StoreLicenseDefault", relatedEntityId.ToString());
		}
		entity.UpdateRefToStoreLicenseDefault(storeLicenseDefaultEntities);

		await DbContext.Entry(entity).Collection(x => x.StoreLicenseSoldIn).LoadAsync();
		var storeLicenseSoldInEntities = new List<ClientApi.Domain.StoreLicense>();
		foreach(var relatedEntityId in request.EntityDto.StoreLicenseSoldInId)
		{
			var relatedKey = ClientApi.Domain.StoreLicenseMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.StoreLicenses.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				storeLicenseSoldInEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("StoreLicenseSoldIn", relatedEntityId.ToString());
		}
		entity.UpdateRefToStoreLicenseSoldIn(storeLicenseSoldInEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CurrencyKeyDto(entity.Id.Value);
	}
}