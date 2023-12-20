﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryBarCodeEntity = ClientApi.Domain.CountryBarCode;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateCountryBarCodeForCountryCommand(CountryKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryBarCodeKeyDto>;

internal partial class PartialUpdateCountryBarCodeForCountryCommandHandler: PartialUpdateCountryBarCodeForCountryCommandHandlerBase
{
	public PartialUpdateCountryBarCodeForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryBarCodeForCountryCommandHandlerBase: CommandBase<PartialUpdateCountryBarCodeForCountryCommand, CountryBarCodeEntity>, IRequestHandler <PartialUpdateCountryBarCodeForCountryCommand, CountryBarCodeKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> _entityFactory;

	protected PartialUpdateCountryBarCodeForCountryCommandHandlerBase(
		AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryBarCodeKeyDto> Handle(PartialUpdateCountryBarCodeForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Country",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Reference(e => e.CountryBarCode).LoadAsync(cancellationToken);
		var entity = parentEntity.CountryBarCode;
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Country.CountryBarCode", String.Empty);
		}

		_entityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		_dbContext.Entry(entity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();

		return new CountryBarCodeKeyDto();
	}
}