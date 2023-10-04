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
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public record CreateCommissionCommand(CommissionCreateDto EntityDto) : IRequest<CommissionKeyDto>;

internal partial class CreateCommissionCommandHandler : CreateCommissionCommandHandlerBase
{
	public CreateCommissionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> countryfactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory)
		: base(dbContext, noxSolution,countryfactory, bookingfactory, entityFactory)
	{
	}
}


internal abstract class CreateCommissionCommandHandlerBase : CommandBase<CreateCommissionCommand,CommissionEntity>, IRequestHandler <CreateCommissionCommand, CommissionKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> _entityFactory;
	private readonly IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> _countryfactory;
	private readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> _bookingfactory;

	public CreateCommissionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> countryfactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_countryfactory = countryfactory;
		_bookingfactory = bookingfactory;
	}

	public virtual async Task<CommissionKeyDto> Handle(CreateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CommissionFeesForCountryId is not null)
		{
			var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.CommissionFeesForCountryId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCommissionFeesForCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CommissionFeesForCountry", request.EntityDto.CommissionFeesForCountryId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.CommissionFeesForCountry is not null)
		{
			var relatedEntity = _countryfactory.CreateEntity(request.EntityDto.CommissionFeesForCountry);
			entityToCreate.CreateRefToCommissionFeesForCountry(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CommissionFeesForBooking)
		{
			var relatedEntity = _bookingfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCommissionFeesForBooking(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.Commissions.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CommissionKeyDto(entityToCreate.Id.Value);
	}
}