﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public partial record UpdateBookingCommand(System.Guid keyId, BookingUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<BookingKeyDto>;

internal partial class UpdateBookingCommandHandler : UpdateBookingCommandHandlerBase
{
	public UpdateBookingCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateBookingCommandHandlerBase : CommandBase<UpdateBookingCommand, BookingEntity>, IRequestHandler<UpdateBookingCommand, BookingKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> EntityFactory { get; }
	protected UpdateBookingCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<BookingKeyDto> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<Cryptocash.Domain.Booking>()
            .Where(x => x.Id == Dto.BookingMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new BookingKeyDto(entity.Id.Value);
	}
}