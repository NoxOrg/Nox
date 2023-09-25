﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryQualityOfLifeIndex = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public record PartialUpdateCountryQualityOfLifeIndexCommand(System.Int64 keyCountryId, System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CountryQualityOfLifeIndexKeyDto?>;

internal class PartialUpdateCountryQualityOfLifeIndexCommandHandler: PartialUpdateCountryQualityOfLifeIndexCommandHandlerBase
{
	public PartialUpdateCountryQualityOfLifeIndexCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryQualityOfLifeIndex, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal class PartialUpdateCountryQualityOfLifeIndexCommandHandlerBase: CommandBase<PartialUpdateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndex>, IRequestHandler<PartialUpdateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<CountryQualityOfLifeIndex, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> EntityFactory { get; }

	public PartialUpdateCountryQualityOfLifeIndexCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryQualityOfLifeIndex, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQualityOfLifeIndexKeyDto?> Handle(PartialUpdateCountryQualityOfLifeIndexCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyCountryId = CreateNoxTypeForKey<CountryQualityOfLifeIndex,Nox.Types.AutoNumber>("CountryId", request.keyCountryId);
		var keyId = CreateNoxTypeForKey<CountryQualityOfLifeIndex,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.CountryQualityOfLifeIndices.FindAsync(keyCountryId, keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CountryQualityOfLifeIndexKeyDto(entity.CountryId.Value, entity.Id.Value);
	}
}