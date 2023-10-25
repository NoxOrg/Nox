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
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public record CreateVendingMachineCommand(VendingMachineCreateDto EntityDto) : IRequest<VendingMachineKeyDto>;

internal partial class CreateVendingMachineCommandHandler : CreateVendingMachineCommandHandlerBase
{
	public CreateVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<Cryptocash.Domain.LandLord, LandLordCreateDto, LandLordUpdateDto> LandLordFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> CashStockOrderFactory,
		IEntityFactory<Cryptocash.Domain.MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> MinimumCashStockFactory,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory)
		: base(dbContext, noxSolution,CountryFactory, LandLordFactory, BookingFactory, CashStockOrderFactory, MinimumCashStockFactory, entityFactory)
	{
	}
}


internal abstract class CreateVendingMachineCommandHandlerBase : CommandBase<CreateVendingMachineCommand,VendingMachineEntity>, IRequestHandler <CreateVendingMachineCommand, VendingMachineKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.LandLord, LandLordCreateDto, LandLordUpdateDto> LandLordFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> CashStockOrderFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> MinimumCashStockFactory;

	public CreateVendingMachineCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<Cryptocash.Domain.LandLord, LandLordCreateDto, LandLordUpdateDto> LandLordFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> CashStockOrderFactory,
		IEntityFactory<Cryptocash.Domain.MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> MinimumCashStockFactory,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CountryFactory = CountryFactory;
		this.LandLordFactory = LandLordFactory;
		this.BookingFactory = BookingFactory;
		this.CashStockOrderFactory = CashStockOrderFactory;
		this.MinimumCashStockFactory = MinimumCashStockFactory;
	}

	public virtual async Task<VendingMachineKeyDto> Handle(CreateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.VendingMachineInstallationCountryId is not null)
		{
			var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.VendingMachineInstallationCountryId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToVendingMachineInstallationCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachineInstallationCountry", request.EntityDto.VendingMachineInstallationCountryId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.VendingMachineInstallationCountry is not null)
		{
			var relatedEntity = CountryFactory.CreateEntity(request.EntityDto.VendingMachineInstallationCountry);
			entityToCreate.CreateRefToVendingMachineInstallationCountry(relatedEntity);
		}
		if(request.EntityDto.VendingMachineContractedAreaLandLordId is not null)
		{
			var relatedKey = Cryptocash.Domain.LandLordMetadata.CreateId(request.EntityDto.VendingMachineContractedAreaLandLordId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.LandLords.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToVendingMachineContractedAreaLandLord(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachineContractedAreaLandLord", request.EntityDto.VendingMachineContractedAreaLandLordId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.VendingMachineContractedAreaLandLord is not null)
		{
			var relatedEntity = LandLordFactory.CreateEntity(request.EntityDto.VendingMachineContractedAreaLandLord);
			entityToCreate.CreateRefToVendingMachineContractedAreaLandLord(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.VendingMachineRelatedBookings)
		{
			var relatedEntity = BookingFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToVendingMachineRelatedBookings(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.VendingMachineRelatedCashStockOrders)
		{
			var relatedEntity = CashStockOrderFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToVendingMachineRelatedCashStockOrders(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.VendingMachineRequiredMinimumCashStocks)
		{
			var relatedEntity = MinimumCashStockFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToVendingMachineRequiredMinimumCashStocks(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.VendingMachines.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new VendingMachineKeyDto(entityToCreate.Id.Value);
	}
}