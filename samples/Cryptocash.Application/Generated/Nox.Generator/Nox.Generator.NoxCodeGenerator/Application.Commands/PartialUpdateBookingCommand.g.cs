// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateBookingCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <BookingKeyDto>;

internal partial class PartialUpdateBookingCommandHandler : PartialUpdateBookingCommandHandlerBase
{
	public PartialUpdateBookingCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateBookingCommandHandlerBase : CommandBase<PartialUpdateBookingCommand, BookingEntity>, IRequestHandler<PartialUpdateBookingCommand, BookingKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> EntityFactory { get; }
	
	public PartialUpdateBookingCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<BookingKeyDto> Handle(PartialUpdateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.BookingMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Booking>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new BookingKeyDto(entity.Id.Value);
	}
}