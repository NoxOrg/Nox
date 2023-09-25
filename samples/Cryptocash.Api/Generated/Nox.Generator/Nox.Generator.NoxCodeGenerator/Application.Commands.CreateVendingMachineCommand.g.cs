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

internal partial class CreateVendingMachineCommandHandler: CreateVendingMachineCommandHandlerBase
{
	public CreateVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> countryfactory,
        IEntityFactory<LandLord, LandLordCreateDto, LandLordUpdateDto> landlordfactory,
        IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
        IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> cashstockorderfactory,
        IEntityFactory<MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> minimumcashstockfactory,
        IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,countryfactory, landlordfactory, bookingfactory, cashstockorderfactory, minimumcashstockfactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateVendingMachineCommandHandlerBase: CommandBase<CreateVendingMachineCommand,VendingMachine>, IRequestHandler <CreateVendingMachineCommand, VendingMachineKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> _entityFactory;
    private readonly IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> _countryfactory;
    private readonly IEntityFactory<LandLord, LandLordCreateDto, LandLordUpdateDto> _landlordfactory;
    private readonly IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> _bookingfactory;
    private readonly IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> _cashstockorderfactory;
    private readonly IEntityFactory<MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> _minimumcashstockfactory;

	public CreateVendingMachineCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> countryfactory,
        IEntityFactory<LandLord, LandLordCreateDto, LandLordUpdateDto> landlordfactory,
        IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
        IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> cashstockorderfactory,
        IEntityFactory<MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> minimumcashstockfactory,
        IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory,
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

	public virtual async Task<VendingMachineKeyDto> Handle(CreateVendingMachineCommand request, CancellationToken cancellationToken)
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