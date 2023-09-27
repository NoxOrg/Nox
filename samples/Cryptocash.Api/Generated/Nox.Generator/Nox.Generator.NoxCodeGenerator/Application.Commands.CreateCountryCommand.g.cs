﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Country = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public record CreateCountryCommand(CountryCreateDto EntityDto) : IRequest<CountryKeyDto>;

internal partial class CreateCountryCommandHandler: CreateCountryCommandHandlerBase
{
	public CreateCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> currencyfactory,
		IEntityFactory<Commission, CommissionCreateDto, CommissionUpdateDto> commissionfactory,
		IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
		IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,currencyfactory, commissionfactory, vendingmachinefactory, customerfactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateCountryCommandHandlerBase: CommandBase<CreateCountryCommand,Country>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> _entityFactory;
	private readonly IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> _currencyfactory;
	private readonly IEntityFactory<Commission, CommissionCreateDto, CommissionUpdateDto> _commissionfactory;
	private readonly IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> _vendingmachinefactory;
	private readonly IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> _customerfactory;

	public CreateCountryCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> currencyfactory,
		IEntityFactory<Commission, CommissionCreateDto, CommissionUpdateDto> commissionfactory,
		IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
		IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
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
		if(request.EntityDto.CountryUsedByCurrency is not null)
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

		OnCompleted(request, entityToCreate);
		_dbContext.Countries.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CountryKeyDto(entityToCreate.Id.Value);
	}
}