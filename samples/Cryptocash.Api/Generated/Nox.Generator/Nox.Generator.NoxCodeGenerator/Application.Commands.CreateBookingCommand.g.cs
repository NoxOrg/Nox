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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateBookingCommand(BookingCreateDto EntityDto) : IRequest<BookingKeyDto>;

public partial class CreateBookingCommandHandler: CommandBase<CreateBookingCommand,Booking>, IRequestHandler <CreateBookingCommand, BookingKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<BookingCreateDto,Booking> EntityFactory { get; }

	public CreateBookingCommandHandler(
		CryptocashApiDbContext dbContext,
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