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

public partial class CreateCountryCommandHandler: CommandBase<CreateCountryCommand,Country>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<Country,CountryCreateDto> _entityFactory;
    private readonly IEntityFactory<Currency,CurrencyCreateDto> _currencyfactory;
    private readonly IEntityFactory<Commission,CommissionCreateDto> _commissionfactory;
    private readonly IEntityFactory<VendingMachine,VendingMachineCreateDto> _vendingmachinefactory;
    private readonly IEntityFactory<Customer,CustomerCreateDto> _customerfactory;

	public CreateCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Currency,CurrencyCreateDto> currencyfactory,
        IEntityFactory<Commission,CommissionCreateDto> commissionfactory,
        IEntityFactory<VendingMachine,VendingMachineCreateDto> vendingmachinefactory,
        IEntityFactory<Customer,CustomerCreateDto> customerfactory,
        IEntityFactory<Country,CountryCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;        
        _currencyfactory = currencyfactory;        
        _commissionfactory = commissionfactory;        
        _vendingmachinefactory = vendingmachinefactory;        
        _customerfactory = customerfactory;
	}

	public async Task<CountryKeyDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CountryUsedByCurrency is not null)
		{ 
			var relatedEntity = _currencyfactory.CreateEntity(request.EntityDto.CountryUsedByCurrency);
			entityToCreate.CreateRefToCurrency(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CountryUsedByCommissions)
		{
			var relatedEntity = _commissionfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCommission(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CountryUsedByVendingMachines)
		{
			var relatedEntity = _vendingmachinefactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToVendingMachine(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CountryUsedByCustomers)
		{
			var relatedEntity = _customerfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCustomer(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.Countries.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CountryKeyDto(entityToCreate.Id.Value);
	}
}