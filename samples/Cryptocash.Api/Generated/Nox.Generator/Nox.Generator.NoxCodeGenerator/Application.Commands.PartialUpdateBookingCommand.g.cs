﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Booking = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public record PartialUpdateBookingCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <BookingKeyDto?>;

internal class PartialUpdateBookingCommandHandler: PartialUpdateBookingCommandHandlerBase
{
	public PartialUpdateBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal class PartialUpdateBookingCommandHandlerBase: CommandBase<PartialUpdateBookingCommand, Booking>, IRequestHandler<PartialUpdateBookingCommand, BookingKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> EntityFactory { get; }

	public PartialUpdateBookingCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<BookingKeyDto?> Handle(PartialUpdateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Booking,Nox.Types.Guid>("Id", request.keyId);

		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new BookingKeyDto(entity.Id.Value);
	}
}