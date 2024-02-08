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

public abstract record RefBookingToCustomerCommand(BookingKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefBookingToCustomerCommand(BookingKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefBookingToCustomerCommand(EntityKeyDto);

internal partial class CreateRefBookingToCustomerCommandHandler
	: RefBookingToCustomerCommandHandlerBase<CreateRefBookingToCustomerCommand>
{
	public CreateRefBookingToCustomerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefBookingToCustomerCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBookingForCustomer(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Customer",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCustomer(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefBookingToCustomerCommand(BookingKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefBookingToCustomerCommand(EntityKeyDto);

internal partial class DeleteRefBookingToCustomerCommandHandler
	: RefBookingToCustomerCommandHandlerBase<DeleteRefBookingToCustomerCommand>
{
	public DeleteRefBookingToCustomerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefBookingToCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBookingForCustomer(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Customer", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCustomer(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefBookingToCustomerCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToCustomerCommand(EntityKeyDto);

internal partial class DeleteAllRefBookingToCustomerCommandHandler
	: RefBookingToCustomerCommandHandlerBase<DeleteAllRefBookingToCustomerCommand>
{
	public DeleteAllRefBookingToCustomerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefBookingToCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCustomer();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefBookingToCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToCustomerCommand
{
	public IRepository Repository { get; }

	public RefBookingToCustomerCommandHandlerBase(
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
		return await Repository.FindAsync<Cryptocash.Domain.Booking>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Customer?> GetBookingForCustomer(CustomerKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CustomerMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Cryptocash.Domain.Customer>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, BookingEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}