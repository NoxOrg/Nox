﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryBarCodeEntity = ClientApi.Domain.CountryBarCode;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public partial record UpdateCountryBarCodeForCountryCommand(CountryKeyDto ParentKeyDto, CountryBarCodeUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryBarCodeKeyDto>;

internal partial class UpdateCountryBarCodeForCountryCommandHandler : UpdateCountryBarCodeForCountryCommandHandlerBase
{
	public UpdateCountryBarCodeForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateCountryBarCodeForCountryCommandHandlerBase : CommandBase<UpdateCountryBarCodeForCountryCommand, CountryBarCodeEntity>, IRequestHandler <UpdateCountryBarCodeForCountryCommand, CountryBarCodeKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> _entityFactory;

	protected UpdateCountryBarCodeForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryBarCodeKeyDto> Handle(UpdateCountryBarCodeForCountryCommand request, CancellationToken cancellationToken)
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
		if (entity is null)
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		else
			await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity!);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;


		var result = await _dbContext.SaveChangesAsync();

		return new CountryBarCodeKeyDto();
	}
	
	private async Task<CountryBarCodeEntity> CreateEntityAsync(CountryBarCodeUpsertDto upsertDto, CountryEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToCountryBarCode(entity);
		return entity;
	}
}