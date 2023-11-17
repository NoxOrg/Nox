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
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public record UpdateCountryQualityOfLifeIndexCommand(System.Int64 keyCountryId, System.Int64 keyId, CountryQualityOfLifeIndexUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryQualityOfLifeIndexKeyDto?>;

internal partial class UpdateCountryQualityOfLifeIndexCommandHandler : UpdateCountryQualityOfLifeIndexCommandHandlerBase
{
	public UpdateCountryQualityOfLifeIndexCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCountryQualityOfLifeIndexCommandHandlerBase : CommandBase<UpdateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexEntity>, IRequestHandler<UpdateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> _entityFactory;

	public UpdateCountryQualityOfLifeIndexCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryQualityOfLifeIndexKeyDto?> Handle(UpdateCountryQualityOfLifeIndexCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyCountryId = ClientApi.Domain.CountryQualityOfLifeIndexMetadata.CreateCountryId(request.keyCountryId);
		var keyId = ClientApi.Domain.CountryQualityOfLifeIndexMetadata.CreateId(request.keyId);

		var entity = await DbContext.CountryQualityOfLifeIndices.FindAsync(keyCountryId, keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryQualityOfLifeIndexKeyDto(entity.CountryId.Value, entity.Id.Value);
	}
}