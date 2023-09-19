﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Booking = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public record UpdateBookingCommand(System.Guid keyId, BookingUpdateDto EntityDto, System.Guid? Etag) : IRequest<BookingKeyDto?>;

public partial class UpdateBookingCommandHandler: UpdateBookingCommandHandlerBase
{
	public UpdateBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Booking> entityMapper): base(dbContext, noxSolution, serviceProvider, entityMapper)
	{
	}
}
public abstract class UpdateBookingCommandHandlerBase: CommandBase<UpdateBookingCommand, Booking>, IRequestHandler<UpdateBookingCommand, BookingKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Booking> EntityMapper { get; }

	public UpdateBookingCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Booking> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public virtual async Task<BookingKeyDto?> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Booking,Nox.Types.Guid>("Id", request.keyId);
	
		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<Booking>(), request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new BookingKeyDto(entity.Id.Value);
	}
}