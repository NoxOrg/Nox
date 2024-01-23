// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public partial record DeleteBookingByIdCommand(IEnumerable<BookingKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteBookingByIdCommandHandler : DeleteBookingByIdCommandHandlerBase
{
	public DeleteBookingByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteBookingByIdCommandHandlerBase : CommandCollectionBase<DeleteBookingByIdCommand, BookingEntity>, IRequestHandler<DeleteBookingByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteBookingByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteBookingByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<BookingEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.BookingMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<Booking>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Booking",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<BookingEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}