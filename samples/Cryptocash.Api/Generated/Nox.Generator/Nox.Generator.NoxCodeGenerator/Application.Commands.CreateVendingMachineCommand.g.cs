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
using VendingMachine = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public record CreateVendingMachineCommand(VendingMachineCreateDto EntityDto) : IRequest<VendingMachineKeyDto>;

public partial class CreateVendingMachineCommandHandler: CommandBase<CreateVendingMachineCommand,VendingMachine>, IRequestHandler <CreateVendingMachineCommand, VendingMachineKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<VendingMachine,VendingMachineCreateDto> _entityFactory;
    private readonly IEntityFactory<Country,CountryCreateDto> _countryfactory;
    private readonly IEntityFactory<LandLord,LandLordCreateDto> _landlordfactory;
    private readonly IEntityFactory<Booking,BookingCreateDto> _bookingfactory;
    private readonly IEntityFactory<CashStockOrder,CashStockOrderCreateDto> _cashstockorderfactory;
    private readonly IEntityFactory<MinimumCashStock,MinimumCashStockCreateDto> _minimumcashstockfactory;

	public CreateVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Country,CountryCreateDto> countryfactory,
        IEntityFactory<LandLord,LandLordCreateDto> landlordfactory,
        IEntityFactory<Booking,BookingCreateDto> bookingfactory,
        IEntityFactory<CashStockOrder,CashStockOrderCreateDto> cashstockorderfactory,
        IEntityFactory<MinimumCashStock,MinimumCashStockCreateDto> minimumcashstockfactory,
        IEntityFactory<VendingMachine,VendingMachineCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;        
        _countryfactory = countryfactory;        
        _landlordfactory = landlordfactory;        
        _bookingfactory = bookingfactory;        
        _cashstockorderfactory = cashstockorderfactory;        
        _minimumcashstockfactory = minimumcashstockfactory;
	}

	public async Task<VendingMachineKeyDto> Handle(CreateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.VendingMachineInstallationCountry is not null)
		{ 
			var relatedEntity = _countryfactory.CreateEntity(request.EntityDto.VendingMachineInstallationCountry);
			entityToCreate.CreateRefToVendingMachineInstallationCountry(relatedEntity);
		}
		if(request.EntityDto.VendingMachineContractedAreaLandLord is not null)
		{ 
			var relatedEntity = _landlordfactory.CreateEntity(request.EntityDto.VendingMachineContractedAreaLandLord);
			entityToCreate.CreateRefToVendingMachineContractedAreaLandLord(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.VendingMachineRelatedBookings)
		{
			var relatedEntity = _bookingfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToVendingMachineRelatedBookings(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.VendingMachineRelatedCashStockOrders)
		{
			var relatedEntity = _cashstockorderfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToVendingMachineRelatedCashStockOrders(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.VendingMachineRequiredMinimumCashStocks)
		{
			var relatedEntity = _minimumcashstockfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToVendingMachineRequiredMinimumCashStocks(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.VendingMachines.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new VendingMachineKeyDto(entityToCreate.Id.Value);
	}
}