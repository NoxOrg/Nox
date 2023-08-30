﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record UpdateBookingCommand(System.Guid keyId, BookingUpdateDto EntityDto) : IRequest<BookingKeyDto?>;

public class UpdateBookingCommandHandler: CommandBase<UpdateBookingCommand, Booking>, IRequestHandler<UpdateBookingCommand, BookingKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<Booking> EntityMapper { get; }

	public UpdateBookingCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Booking> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<BookingKeyDto?> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Booking,DatabaseGuid>("Id", request.keyId);
	
		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<Booking>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new BookingKeyDto(entity.Id.Value);
	}
}