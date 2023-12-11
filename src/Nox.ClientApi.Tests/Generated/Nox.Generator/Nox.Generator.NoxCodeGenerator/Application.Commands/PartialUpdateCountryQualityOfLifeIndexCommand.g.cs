﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateCountryQualityOfLifeIndexCommand(System.Int64 keyCountryId, System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryQualityOfLifeIndexKeyDto?>;

internal partial class PartialUpdateCountryQualityOfLifeIndexCommandHandler : PartialUpdateCountryQualityOfLifeIndexCommandHandlerBase
{
	public PartialUpdateCountryQualityOfLifeIndexCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryQualityOfLifeIndexCommandHandlerBase : CommandBase<PartialUpdateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexEntity>, IRequestHandler<PartialUpdateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> EntityFactory { get; }

	public PartialUpdateCountryQualityOfLifeIndexCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQualityOfLifeIndexKeyDto?> Handle(PartialUpdateCountryQualityOfLifeIndexCommand request, CancellationToken cancellationToken)
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
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CountryQualityOfLifeIndexKeyDto(entity.CountryId.Value, entity.Id.Value);
	}
}