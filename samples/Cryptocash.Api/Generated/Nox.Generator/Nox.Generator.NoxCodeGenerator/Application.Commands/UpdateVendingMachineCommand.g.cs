﻿// Generated

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

public record UpdateVendingMachineCommand(System.Guid keyId, VendingMachineUpdateDto EntityDto, System.Guid? Etag) : IRequest<VendingMachineKeyDto?>;

internal partial class UpdateVendingMachineCommandHandler : UpdateVendingMachineCommandHandlerBase
{
	public UpdateVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
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
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory) : base(noxSolution)
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

		var vendingMachineInstallationCountryKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.VendingMachineInstallationCountryId);
		var vendingMachineInstallationCountryEntity = await DbContext.Countries.FindAsync(vendingMachineInstallationCountryKey);
						
		if(vendingMachineInstallationCountryEntity is not null)
			entity.CreateRefToVendingMachineInstallationCountry(vendingMachineInstallationCountryEntity);
		else
			throw new RelatedEntityNotFoundException("VendingMachineInstallationCountry", request.EntityDto.VendingMachineInstallationCountryId.ToString());

		var vendingMachineContractedAreaLandLordKey = Cryptocash.Domain.LandLordMetadata.CreateId(request.EntityDto.VendingMachineContractedAreaLandLordId);
		var vendingMachineContractedAreaLandLordEntity = await DbContext.LandLords.FindAsync(vendingMachineContractedAreaLandLordKey);
						
		if(vendingMachineContractedAreaLandLordEntity is not null)
			entity.CreateRefToVendingMachineContractedAreaLandLord(vendingMachineContractedAreaLandLordEntity);
		else
			throw new RelatedEntityNotFoundException("VendingMachineContractedAreaLandLord", request.EntityDto.VendingMachineContractedAreaLandLordId.ToString());

		await DbContext.Entry(entity).Collection(x => x.VendingMachineRelatedBookings).LoadAsync();
		var vendingMachineRelatedBookingsEntities = new List<Booking>();
		foreach(var relatedEntityId in request.EntityDto.VendingMachineRelatedBookingsId)
		{
			var relatedKey = Cryptocash.Domain.BookingMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Bookings.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				vendingMachineRelatedBookingsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachineRelatedBookings", relatedEntityId.ToString());
		}
		entity.UpdateRefToVendingMachineRelatedBookings(vendingMachineRelatedBookingsEntities);

		await DbContext.Entry(entity).Collection(x => x.VendingMachineRelatedCashStockOrders).LoadAsync();
		var vendingMachineRelatedCashStockOrdersEntities = new List<CashStockOrder>();
		foreach(var relatedEntityId in request.EntityDto.VendingMachineRelatedCashStockOrdersId)
		{
			var relatedKey = Cryptocash.Domain.CashStockOrderMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.CashStockOrders.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				vendingMachineRelatedCashStockOrdersEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachineRelatedCashStockOrders", relatedEntityId.ToString());
		}
		entity.UpdateRefToVendingMachineRelatedCashStockOrders(vendingMachineRelatedCashStockOrdersEntities);

		await DbContext.Entry(entity).Collection(x => x.VendingMachineRequiredMinimumCashStocks).LoadAsync();
		var vendingMachineRequiredMinimumCashStocksEntities = new List<MinimumCashStock>();
		foreach(var relatedEntityId in request.EntityDto.VendingMachineRequiredMinimumCashStocksId)
		{
			var relatedKey = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.MinimumCashStocks.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				vendingMachineRequiredMinimumCashStocksEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachineRequiredMinimumCashStocks", relatedEntityId.ToString());
		}
		entity.UpdateRefToVendingMachineRequiredMinimumCashStocks(vendingMachineRequiredMinimumCashStocksEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto);
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