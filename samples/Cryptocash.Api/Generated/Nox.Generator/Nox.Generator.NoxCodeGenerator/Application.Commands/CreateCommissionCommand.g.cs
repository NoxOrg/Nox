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

public record CreateCommissionCommand(CommissionCreateDto EntityDto) : IRequest<CommissionKeyDto>;

internal partial class CreateCommissionCommandHandler : CreateCommissionCommandHandlerBase
{
	public CreateCommissionCommandHandler(
		CryptocashDbContext dbContext,
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
	protected readonly CryptocashDbContext DbContext;
	protected readonly IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory;

	public CreateCommissionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CountryFactory = CountryFactory;
		this.BookingFactory = BookingFactory;
	}

	public virtual async Task<CommissionKeyDto> Handle(CreateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CommissionFeesForCountryId is not null)
		{
			var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.CommissionFeesForCountryId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCommissionFeesForCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CommissionFeesForCountry", request.EntityDto.CommissionFeesForCountryId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.CommissionFeesForCountry is not null)
		{
			var relatedEntity = CountryFactory.CreateEntity(request.EntityDto.CommissionFeesForCountry);
			entityToCreate.CreateRefToCommissionFeesForCountry(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CommissionFeesForBooking)
		{
			var relatedEntity = BookingFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCommissionFeesForBooking(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Commissions.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CommissionKeyDto(entityToCreate.Id.Value);
	}
}