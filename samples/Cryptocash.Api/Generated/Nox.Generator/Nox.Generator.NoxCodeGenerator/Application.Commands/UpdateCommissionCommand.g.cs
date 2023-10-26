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
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public record UpdateCommissionCommand(System.Int64 keyId, CommissionUpdateDto EntityDto, System.Guid? Etag) : IRequest<CommissionKeyDto?>;

internal partial class UpdateCommissionCommandHandler : UpdateCommissionCommandHandlerBase
{
	public UpdateCommissionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCommissionCommandHandlerBase : CommandBase<UpdateCommissionCommand, CommissionEntity>, IRequestHandler<UpdateCommissionCommand, CommissionKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> _entityFactory;

	public UpdateCommissionCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CommissionKeyDto?> Handle(UpdateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CommissionMetadata.CreateId(request.keyId);

		var entity = await DbContext.Commissions.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		if(request.EntityDto.CommissionFeesForCountryId is not null)
		{
			var commissionFeesForCountryKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.CommissionFeesForCountryId.NonNullValue<System.String>());
			var commissionFeesForCountryEntity = await DbContext.Countries.FindAsync(commissionFeesForCountryKey);
						
			if(commissionFeesForCountryEntity is not null)
				entity.CreateRefToCommissionFeesForCountry(commissionFeesForCountryEntity);
			else
				throw new RelatedEntityNotFoundException("CommissionFeesForCountry", request.EntityDto.CommissionFeesForCountryId.NonNullValue<System.String>().ToString());
		}
		else
		{
			entity.DeleteAllRefToCommissionFeesForCountry();
		}

		await DbContext.Entry(entity).Collection(x => x.CommissionFeesForBooking).LoadAsync();
		var commissionFeesForBookingEntities = new List<Booking>();
		foreach(var relatedEntityId in request.EntityDto.CommissionFeesForBookingId)
		{
			var relatedKey = Cryptocash.Domain.BookingMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Bookings.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				commissionFeesForBookingEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CommissionFeesForBooking", relatedEntityId.ToString());
		}
		entity.UpdateRefToCommissionFeesForBooking(commissionFeesForBookingEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CommissionKeyDto(entity.Id.Value);
	}
}