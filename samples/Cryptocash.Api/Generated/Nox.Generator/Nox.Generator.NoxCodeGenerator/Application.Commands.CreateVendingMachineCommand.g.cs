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
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public record CreateVendingMachineCommand(VendingMachineCreateDto EntityDto) : IRequest<VendingMachineKeyDto>;

internal partial class CreateVendingMachineCommandHandler : CreateVendingMachineCommandHandlerBase
{
	public CreateVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> countryfactory,
		IEntityFactory<Cryptocash.Domain.LandLord, LandLordCreateDto, LandLordUpdateDto> landlordfactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
		IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> cashstockorderfactory,
		IEntityFactory<Cryptocash.Domain.MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> minimumcashstockfactory,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory)
		: base(dbContext, noxSolution,countryfactory, landlordfactory, bookingfactory, cashstockorderfactory, minimumcashstockfactory, entityFactory)
	{
	}
}


internal abstract class CreateVendingMachineCommandHandlerBase : CommandBase<CreateVendingMachineCommand,VendingMachineEntity>, IRequestHandler <CreateVendingMachineCommand, VendingMachineKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> _entityFactory;
	private readonly IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> _countryfactory;
	private readonly IEntityFactory<Cryptocash.Domain.LandLord, LandLordCreateDto, LandLordUpdateDto> _landlordfactory;
	private readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> _bookingfactory;
	private readonly IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> _cashstockorderfactory;
	private readonly IEntityFactory<Cryptocash.Domain.MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> _minimumcashstockfactory;

	public CreateVendingMachineCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> countryfactory,
		IEntityFactory<Cryptocash.Domain.LandLord, LandLordCreateDto, LandLordUpdateDto> landlordfactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
		IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> cashstockorderfactory,
		IEntityFactory<Cryptocash.Domain.MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> minimumcashstockfactory,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory) : base(noxSolution)
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
		if(request.EntityDto.VendingMachineInstallationCountryId is not null)
		{
			var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.VendingMachineInstallationCountryId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToVendingMachineInstallationCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachineInstallationCountry", request.EntityDto.VendingMachineInstallationCountryId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.VendingMachineInstallationCountry is not null)
		{
			var relatedEntity = _countryfactory.CreateEntity(request.EntityDto.VendingMachineInstallationCountry);
			entityToCreate.CreateRefToVendingMachineInstallationCountry(relatedEntity);
		}
		if(request.EntityDto.VendingMachineContractedAreaLandLordId is not null)
		{
			var relatedKey = Cryptocash.Domain.LandLordMetadata.CreateId(request.EntityDto.VendingMachineContractedAreaLandLordId.NonNullValue<System.Int64>());
			var relatedEntity = await _dbContext.LandLords.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToVendingMachineContractedAreaLandLord(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachineContractedAreaLandLord", request.EntityDto.VendingMachineContractedAreaLandLordId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.VendingMachineContractedAreaLandLord is not null)
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