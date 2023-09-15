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
using CountryBarCode = ClientApi.Domain.CountryBarCode;

namespace ClientApi.Application.Commands;
public record CreateCountryBarCodeForCountryCommand(CountryKeyDto ParentKeyDto, CountryBarCodeCreateDto EntityDto, System.Guid? Etag) : IRequest <CountryBarCodeKeyDto?>;

public partial class CreateCountryBarCodeForCountryCommandHandler: CreateCountryBarCodeForCountryCommandHandlerBase
{
	public CreateCountryBarCodeForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CountryBarCode,CountryBarCodeCreateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution, entityFactory, serviceProvider)
	{
	}
}
public abstract class CreateCountryBarCodeForCountryCommandHandlerBase: CommandBase<CreateCountryBarCodeForCountryCommand, CountryBarCode>, IRequestHandler<CreateCountryBarCodeForCountryCommand, CountryBarCodeKeyDto?>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<CountryBarCode,CountryBarCodeCreateDto> _entityFactory;

	public CreateCountryBarCodeForCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CountryBarCode,CountryBarCodeCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;	
	}

	public virtual  async Task<CountryBarCodeKeyDto?> Handle(CreateCountryBarCodeForCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.AutoNumber>("Id", request.ParentKeyDto.keyId);

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