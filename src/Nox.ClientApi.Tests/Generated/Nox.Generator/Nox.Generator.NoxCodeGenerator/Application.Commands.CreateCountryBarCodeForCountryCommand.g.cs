﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryBarCodeEntity = ClientApi.Domain.CountryBarCode;

namespace ClientApi.Application.Commands;
public record CreateCountryBarCodeForCountryCommand(CountryKeyDto ParentKeyDto, CountryBarCodeCreateDto EntityDto, System.Guid? Etag) : IRequest <CountryBarCodeKeyDto?>;

internal partial class CreateCountryBarCodeForCountryCommandHandler : CreateCountryBarCodeForCountryCommandHandlerBase
{
	public CreateCountryBarCodeForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryBarCodeEntity, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateCountryBarCodeForCountryCommandHandlerBase : CommandBase<CreateCountryBarCodeForCountryCommand, CountryBarCodeEntity>, IRequestHandler<CreateCountryBarCodeForCountryCommand, CountryBarCodeKeyDto?>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<CountryBarCodeEntity, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> _entityFactory;

	public CreateCountryBarCodeForCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryBarCodeEntity, CountryBarCodeCreateDto, CountryBarCodeUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<CountryBarCodeKeyDto?> Handle(CreateCountryBarCodeForCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CountryBarCode = entity;
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryBarCodeKeyDto();
	}
}