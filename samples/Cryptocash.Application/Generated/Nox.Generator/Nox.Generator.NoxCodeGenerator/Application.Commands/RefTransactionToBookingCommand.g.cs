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
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public abstract record RefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefTransactionToBookingCommand(EntityKeyDto);

internal partial class CreateRefTransactionToBookingCommandHandler
	: RefTransactionToBookingCommandHandlerBase<CreateRefTransactionToBookingCommand>
{
	public CreateRefTransactionToBookingCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTransactionToBookingCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTransaction(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTransactionForBooking(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToBooking(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefTransactionToBookingCommand(EntityKeyDto);

internal partial class DeleteRefTransactionToBookingCommandHandler
	: RefTransactionToBookingCommandHandlerBase<DeleteRefTransactionToBookingCommand>
{
	public DeleteRefTransactionToBookingCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTransactionToBookingCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTransaction(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTransactionForBooking(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToBooking(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto)
	: RefTransactionToBookingCommand(EntityKeyDto);

internal partial class DeleteAllRefTransactionToBookingCommandHandler
	: RefTransactionToBookingCommandHandlerBase<DeleteAllRefTransactionToBookingCommand>
{
	public DeleteAllRefTransactionToBookingCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTransactionToBookingCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTransaction(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToBooking();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTransactionToBookingCommandHandlerBase<TRequest> : CommandBase<TRequest, TransactionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTransactionToBookingCommand
{
	public IRepository Repository { get; }

	public RefTransactionToBookingCommandHandlerBase(
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

	protected async Task<TransactionEntity?> GetTransaction(TransactionKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TransactionMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<Transaction>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Booking?> GetTransactionForBooking(BookingKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.BookingMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Booking>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TransactionEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}