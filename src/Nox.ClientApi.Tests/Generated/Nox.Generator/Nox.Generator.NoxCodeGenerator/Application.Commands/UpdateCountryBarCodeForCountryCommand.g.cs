﻿﻿// Generated

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
public record UpdateCountryBarCodeForCountryCommand(CountryKeyDto ParentKeyDto, CountryBarCodeUpdateDto EntityDto, System.Guid? Etag) : IRequest <CountryBarCodeKeyDto?>;


internal partial class UpdateCountryBarCodeForCountryCommandHandler : UpdateCountryBarCodeForCountryCommandHandlerBase
{
	public UpdateCountryBarCodeForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryBarCodeEntity, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateCountryBarCodeForCountryCommandHandlerBase : CommandBase<UpdateCountryBarCodeForCountryCommand, CountryBarCodeEntity>, IRequestHandler <UpdateCountryBarCodeForCountryCommand, CountryBarCodeKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<CountryBarCodeEntity, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> _entityFactory;

	public UpdateCountryBarCodeForCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryBarCodeEntity, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryBarCodeKeyDto?> Handle(UpdateCountryBarCodeForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
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

		_entityFactory.UpdateEntity(entity, request.EntityDto);
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