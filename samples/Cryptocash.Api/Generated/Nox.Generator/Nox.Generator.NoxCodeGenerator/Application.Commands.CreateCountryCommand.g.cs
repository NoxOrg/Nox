﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public record CreateCountryCommand(CountryCreateDto EntityDto) : IRequest<CountryKeyDto>;

internal partial class CreateCountryCommandHandler : CreateCountryCommandHandlerBase
{
	public CreateCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> currencyfactory,
		IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> commissionfactory,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(dbContext, noxSolution,currencyfactory, commissionfactory, vendingmachinefactory, customerfactory, entityFactory)
	{
	}
}


internal abstract class CreateCountryCommandHandlerBase : CommandBase<CreateCountryCommand,CountryEntity>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> _entityFactory;
	private readonly IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> _currencyfactory;
	private readonly IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> _commissionfactory;
	private readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> _vendingmachinefactory;
	private readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> _customerfactory;

	public CreateCountryCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> currencyfactory,
		IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> commissionfactory,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_currencyfactory = currencyfactory;
		_commissionfactory = commissionfactory;
		_vendingmachinefactory = vendingmachinefactory;
		_customerfactory = customerfactory;
	}

	public virtual async Task<CountryKeyDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CountryUsedByCurrencyId is not null)
		{
			var relatedKey = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityDto.CountryUsedByCurrencyId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.Currencies.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCountryUsedByCurrency(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CountryUsedByCurrency", request.EntityDto.CountryUsedByCurrencyId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.CountryUsedByCurrency is not null)
		{
			var relatedEntity = _currencyfactory.CreateEntity(request.EntityDto.CountryUsedByCurrency);
			entityToCreate.CreateRefToCountryUsedByCurrency(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CountryUsedByCommissions)
		{
			var relatedEntity = _commissionfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCountryUsedByCommissions(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CountryUsedByVendingMachines)
		{
			var relatedEntity = _vendingmachinefactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCountryUsedByVendingMachines(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CountryUsedByCustomers)
		{
			var relatedEntity = _customerfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCountryUsedByCustomers(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.Countries.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CountryKeyDto(entityToCreate.Id.Value);
	}
}