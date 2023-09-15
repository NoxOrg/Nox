﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Commission = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public record CreateCommissionCommand(CommissionCreateDto EntityDto) : IRequest<CommissionKeyDto>;

public partial class CreateCommissionCommandHandler: CommandBase<CreateCommissionCommand,Commission>, IRequestHandler <CreateCommissionCommand, CommissionKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<Commission,CommissionCreateDto> _entityFactory;
    private readonly IEntityFactory<Country,CountryCreateDto> _countryfactory;
    private readonly IEntityFactory<Booking,BookingCreateDto> _bookingfactory;

	public CreateCommissionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Country,CountryCreateDto> countryfactory,
        IEntityFactory<Booking,BookingCreateDto> bookingfactory,
        IEntityFactory<Commission,CommissionCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;        
        _countryfactory = countryfactory;        
        _bookingfactory = bookingfactory;
	}

	public async Task<CommissionKeyDto> Handle(CreateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CommissionFeesForCountry is not null)
		{ 
			var relatedEntity = _countryfactory.CreateEntity(request.EntityDto.CommissionFeesForCountry);
			entityToCreate.CreateRefToCountryCommissionFeesForCountry(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CommissionFeesForBooking)
		{
			var relatedEntity = _bookingfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToBookingCommissionFeesForBooking(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.Commissions.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CommissionKeyDto(entityToCreate.Id.Value);
	}
}