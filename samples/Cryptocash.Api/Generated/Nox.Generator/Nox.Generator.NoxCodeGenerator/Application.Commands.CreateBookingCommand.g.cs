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
using Booking = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public record CreateBookingCommand(BookingCreateDto EntityDto) : IRequest<BookingKeyDto>;

public partial class CreateBookingCommandHandler: CommandBase<CreateBookingCommand,Booking>, IRequestHandler <CreateBookingCommand, BookingKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<BookingCreateDto,Booking> _entityFactory;

	public CreateBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<BookingCreateDto,Booking> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public async Task<BookingKeyDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
					
		OnCompleted(entityToCreate);
		_dbContext.Bookings.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new BookingKeyDto(entityToCreate.Id.Value);
	}
}