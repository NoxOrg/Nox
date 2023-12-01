// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public partial record DeleteBookingByIdCommand(IEnumerable<BookingKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteBookingByIdCommandHandler : DeleteBookingByIdCommandHandlerBase
{
	public DeleteBookingByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteBookingByIdCommandHandlerBase : CommandBase<DeleteBookingByIdCommand, BookingEntity>, IRequestHandler<DeleteBookingByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteBookingByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteBookingByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = Cryptocash.Domain.BookingMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Bookings.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new BookingEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}