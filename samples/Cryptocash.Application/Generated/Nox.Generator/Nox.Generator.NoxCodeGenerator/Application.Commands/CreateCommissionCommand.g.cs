﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public partial record CreateCommissionCommand(CommissionCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CommissionKeyDto>;

internal partial class CreateCommissionCommandHandler : CreateCommissionCommandHandlerBase
{
	public CreateCommissionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory)
		: base(repository, noxSolution,CountryFactory, BookingFactory, entityFactory)
	{
	}
}


internal abstract class CreateCommissionCommandHandlerBase : CommandBase<CreateCommissionCommand,CommissionEntity>, IRequestHandler <CreateCommissionCommand, CommissionKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory;

	protected CreateCommissionCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.CountryFactory = CountryFactory;
		this.BookingFactory = BookingFactory;
	}

	public virtual async Task<CommissionKeyDto> Handle(CreateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.CountryId is not null)
		{
			var relatedKey = Dto.CountryMetadata.CreateId(request.EntityDto.CountryId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<Country>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Country", request.EntityDto.CountryId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.Country is not null)
		{
			var relatedEntity = await CountryFactory.CreateEntityAsync(request.EntityDto.Country, request.CultureCode);
			entityToCreate.CreateRefToCountry(relatedEntity);
		}
		if(request.EntityDto.BookingsId.Any())
		{
			foreach(var relatedId in request.EntityDto.BookingsId)
			{
				var relatedKey = Dto.BookingMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<Booking>(relatedKey);

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
				var relatedEntity = await BookingFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToBookings(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<Commission>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new CommissionKeyDto(entityToCreate.Id.Value);
	}
}