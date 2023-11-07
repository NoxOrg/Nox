﻿﻿// Generated

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

public record UpdateCommissionCommand(System.Int64 keyId, CommissionUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CommissionKeyDto?>;

internal partial class UpdateCommissionCommandHandler : UpdateCommissionCommandHandlerBase
{
	public UpdateCommissionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
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
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CommissionKeyDto?> Handle(UpdateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CommissionMetadata.CreateId(request.keyId);

		var entity = await DbContext.Commissions.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		if(request.EntityDto.CountryId is not null)
		{
			var countryKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.CountryId.NonNullValue<System.String>());
			var countryEntity = await DbContext.Countries.FindAsync(countryKey);
						
			if(countryEntity is not null)
				entity.CreateRefToCountry(countryEntity);
			else
				throw new RelatedEntityNotFoundException("Country", request.EntityDto.CountryId.NonNullValue<System.String>().ToString());
		}
		else
		{
			entity.DeleteAllRefToCountry();
		}

		await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
		var bookingsEntities = new List<Booking>();
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

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
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