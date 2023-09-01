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
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<BookingCreateDto,Booking> EntityFactory { get; }

	public CreateBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<BookingCreateDto,Booking> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<BookingKeyDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.Bookings.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new BookingKeyDto(entityToCreate.Id.Value);
	}
}