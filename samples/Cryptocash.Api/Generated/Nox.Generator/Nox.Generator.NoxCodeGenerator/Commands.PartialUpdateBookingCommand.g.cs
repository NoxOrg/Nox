﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateBookingCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <BookingKeyDto?>;

public class PartialUpdateBookingCommandHandler: CommandBase<PartialUpdateBookingCommand, Booking>, IRequestHandler<PartialUpdateBookingCommand, BookingKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<Booking> EntityMapper { get; }

	public PartialUpdateBookingCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Booking> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<BookingKeyDto?> Handle(PartialUpdateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Booking,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Booking>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new BookingKeyDto(entity.Id.Value);
	}
}