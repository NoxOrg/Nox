﻿﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public record UpdateVendingMachineCommand(System.Guid keyId, VendingMachineUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<VendingMachineKeyDto?>;

internal partial class UpdateVendingMachineCommandHandler : UpdateVendingMachineCommandHandlerBase
{
	public UpdateVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateVendingMachineCommandHandlerBase : CommandBase<UpdateVendingMachineCommand, VendingMachineEntity>, IRequestHandler<UpdateVendingMachineCommand, VendingMachineKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> _entityFactory;

	public UpdateVendingMachineCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<VendingMachineKeyDto?> Handle(UpdateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.keyId);

		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var countryKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.CountryId);
		var countryEntity = await DbContext.Countries.FindAsync(countryKey);
						
		if(countryEntity is not null)
			entity.CreateRefToCountry(countryEntity);
		else
			throw new RelatedEntityNotFoundException("Country", request.EntityDto.CountryId.ToString());

		var landLordKey = Cryptocash.Domain.LandLordMetadata.CreateId(request.EntityDto.LandLordId);
		var landLordEntity = await DbContext.LandLords.FindAsync(landLordKey);
						
		if(landLordEntity is not null)
			entity.CreateRefToLandLord(landLordEntity);
		else
			throw new RelatedEntityNotFoundException("LandLord", request.EntityDto.LandLordId.ToString());

		await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
		var bookingsEntities = new List<Cryptocash.Domain.Booking>();
		foreach(var relatedEntityId in request.EntityDto.BookingsId)
		{
			var relatedKey = Cryptocash.Domain.BookingMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Bookings.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				bookingsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Bookings", relatedEntityId.ToString());
		}
		entity.UpdateRefToBookings(bookingsEntities);

		await DbContext.Entry(entity).Collection(x => x.CashStockOrders).LoadAsync();
		var cashStockOrdersEntities = new List<Cryptocash.Domain.CashStockOrder>();
		foreach(var relatedEntityId in request.EntityDto.CashStockOrdersId)
		{
			var relatedKey = Cryptocash.Domain.CashStockOrderMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.CashStockOrders.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				cashStockOrdersEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CashStockOrders", relatedEntityId.ToString());
		}
		entity.UpdateRefToCashStockOrders(cashStockOrdersEntities);

		await DbContext.Entry(entity).Collection(x => x.MinimumCashStocks).LoadAsync();
		var minimumCashStocksEntities = new List<Cryptocash.Domain.MinimumCashStock>();
		foreach(var relatedEntityId in request.EntityDto.MinimumCashStocksId)
		{
			var relatedKey = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.MinimumCashStocks.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				minimumCashStocksEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("MinimumCashStocks", relatedEntityId.ToString());
		}
		entity.UpdateRefToMinimumCashStocks(minimumCashStocksEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new VendingMachineKeyDto(entity.Id.Value);
	}
}