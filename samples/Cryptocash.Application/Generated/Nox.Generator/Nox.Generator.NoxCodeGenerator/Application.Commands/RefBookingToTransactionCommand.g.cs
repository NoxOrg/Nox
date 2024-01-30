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

public abstract record RefBookingToTransactionCommand(BookingKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefBookingToTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefBookingToTransactionCommand(EntityKeyDto);

internal partial class CreateRefBookingToTransactionCommandHandler
	: RefBookingToTransactionCommandHandlerBase<CreateRefBookingToTransactionCommand>
{
	public CreateRefBookingToTransactionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefBookingToTransactionCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBookingRelatedTransaction(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Transaction",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTransaction(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefBookingToTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefBookingToTransactionCommand(EntityKeyDto);

internal partial class DeleteRefBookingToTransactionCommandHandler
	: RefBookingToTransactionCommandHandlerBase<DeleteRefBookingToTransactionCommand>
{
	public DeleteRefBookingToTransactionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefBookingToTransactionCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBookingRelatedTransaction(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Transaction", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTransaction(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefBookingToTransactionCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToTransactionCommand(EntityKeyDto);

internal partial class DeleteAllRefBookingToTransactionCommandHandler
	: RefBookingToTransactionCommandHandlerBase<DeleteAllRefBookingToTransactionCommand>
{
	public DeleteAllRefBookingToTransactionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefBookingToTransactionCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTransaction();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefBookingToTransactionCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToTransactionCommand
{
	public IRepository Repository { get; }

	public RefBookingToTransactionCommandHandlerBase(
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

	protected async Task<Cryptocash.Domain.Transaction?> GetBookingRelatedTransaction(TransactionKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TransactionMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Transaction>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, BookingEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}