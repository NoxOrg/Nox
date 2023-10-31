﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryBarCodeEntity = ClientApi.Domain.CountryBarCode;

namespace ClientApi.Application.Commands;
public record PartialUpdateCountryBarCodeForCountryCommand(CountryKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CountryBarCodeKeyDto?>;

internal partial class PartialUpdateCountryBarCodeForCountryCommandHandler: PartialUpdateCountryBarCodeForCountryCommandHandlerBase
{
	public PartialUpdateCountryBarCodeForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryBarCodeEntity, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryBarCodeForCountryCommandHandlerBase: CommandBase<PartialUpdateCountryBarCodeForCountryCommand, CountryBarCodeEntity>, IRequestHandler <PartialUpdateCountryBarCodeForCountryCommand, CountryBarCodeKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<CountryBarCodeEntity, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> EntityFactory { get; }

	public PartialUpdateCountryBarCodeForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryBarCodeEntity, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryBarCodeKeyDto?> Handle(PartialUpdateCountryBarCodeForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var entity = parentEntity.CountryBarCode;
		
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryBarCodeKeyDto();
	}
}