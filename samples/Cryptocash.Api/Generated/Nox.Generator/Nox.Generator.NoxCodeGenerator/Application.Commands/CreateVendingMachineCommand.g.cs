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

public partial record CreateVendingMachineCommand(VendingMachineCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<VendingMachineKeyDto>;

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
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory)
		: base(noxSolution)
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
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CountryId is not null)
		{
			var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.CountryId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Country", request.EntityDto.CountryId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.Country is not null)
		{
			var relatedEntity = CountryFactory.CreateEntity(request.EntityDto.Country);
			entityToCreate.CreateRefToCountry(relatedEntity);
		}
		if(request.EntityDto.LandLordId is not null)
		{
			var relatedKey = Cryptocash.Domain.LandLordMetadata.CreateId(request.EntityDto.LandLordId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.LandLords.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToLandLord(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("LandLord", request.EntityDto.LandLordId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.LandLord is not null)
		{
			var relatedEntity = LandLordFactory.CreateEntity(request.EntityDto.LandLord);
			entityToCreate.CreateRefToLandLord(relatedEntity);
		}
		if(request.EntityDto.BookingsId.Any())
		{
			foreach(var relatedId in request.EntityDto.BookingsId)
			{
				var relatedKey = Cryptocash.Domain.BookingMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Bookings.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToBookings(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Bookings", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Bookings)
			{
				var relatedEntity = BookingFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToBookings(relatedEntity);
			}
		}
		if(request.EntityDto.CashStockOrdersId.Any())
		{
			foreach(var relatedId in request.EntityDto.CashStockOrdersId)
			{
				var relatedKey = Cryptocash.Domain.CashStockOrderMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.CashStockOrders.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToCashStockOrders(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("CashStockOrders", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.CashStockOrders)
			{
				var relatedEntity = CashStockOrderFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToCashStockOrders(relatedEntity);
			}
		}
		if(request.EntityDto.MinimumCashStocksId.Any())
		{
			foreach(var relatedId in request.EntityDto.MinimumCashStocksId)
			{
				var relatedKey = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.MinimumCashStocks.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToMinimumCashStocks(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("MinimumCashStocks", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.MinimumCashStocks)
			{
				var relatedEntity = MinimumCashStockFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToMinimumCashStocks(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.VendingMachines.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new VendingMachineKeyDto(entityToCreate.Id.Value);
	}
}