// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
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

public abstract record RefBookingToCommissionCommand(BookingKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefBookingToCommissionCommand(BookingKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefBookingToCommissionCommand(EntityKeyDto);

internal partial class CreateRefBookingToCommissionCommandHandler
	: RefBookingToCommissionCommandHandlerBase<CreateRefBookingToCommissionCommand>
{
	public CreateRefBookingToCommissionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefBookingToCommissionCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBookingFeesForCommission(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Commission",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCommission(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefBookingToCommissionCommand(BookingKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefBookingToCommissionCommand(EntityKeyDto);

internal partial class DeleteRefBookingToCommissionCommandHandler
	: RefBookingToCommissionCommandHandlerBase<DeleteRefBookingToCommissionCommand>
{
	public DeleteRefBookingToCommissionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefBookingToCommissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBookingFeesForCommission(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Commission", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCommission(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefBookingToCommissionCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToCommissionCommand(EntityKeyDto);

internal partial class DeleteAllRefBookingToCommissionCommandHandler
	: RefBookingToCommissionCommandHandlerBase<DeleteAllRefBookingToCommissionCommand>
{
	public DeleteAllRefBookingToCommissionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefBookingToCommissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCommission();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefBookingToCommissionCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToCommissionCommand
{
	public IRepository Repository { get; }

	public RefBookingToCommissionCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		await ExecuteAsync(request, cancellationToken);
		return true;
	}

	protected abstract Task ExecuteAsync(TRequest request, CancellationToken cancellationToken);

	protected async Task<BookingEntity?> GetBooking(BookingKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.BookingMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<Booking>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Commission?> GetBookingFeesForCommission(CommissionKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CommissionMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Commission>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, BookingEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}