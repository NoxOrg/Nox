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
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public record CreateCommissionCommand(CommissionCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CommissionKeyDto>;

internal partial class CreateCommissionCommandHandler : CreateCommissionCommandHandlerBase
{
	public CreateCommissionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory)
		: base(dbContext, noxSolution,CountryFactory, BookingFactory, entityFactory)
	{
	}
}


internal abstract class CreateCommissionCommandHandlerBase : CommandBase<CreateCommissionCommand,CommissionEntity>, IRequestHandler <CreateCommissionCommand, CommissionKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory;

	public CreateCommissionCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CountryFactory = CountryFactory;
		this.BookingFactory = BookingFactory;
	}

	public virtual async Task<CommissionKeyDto> Handle(CreateCommissionCommand request, CancellationToken cancellationToken)
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

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Commissions.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CommissionKeyDto(entityToCreate.Id.Value);
	}
}