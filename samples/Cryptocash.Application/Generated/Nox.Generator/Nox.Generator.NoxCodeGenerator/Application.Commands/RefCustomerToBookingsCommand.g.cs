// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public abstract record RefCustomerToBookingsCommand(CustomerKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCustomerToBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCustomerToBookingsCommand(EntityKeyDto);

internal partial class CreateRefCustomerToBookingsCommandHandler
	: RefCustomerToBookingsCommandHandlerBase<CreateRefCustomerToBookingsCommand>
{
	public CreateRefCustomerToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCustomerToBookingsCommand request)
    {
		var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomerRelatedBookings(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToBookings(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCustomerToBookingsCommand(CustomerKeyDto EntityKeyDto, List<BookingKeyDto> RelatedEntitiesKeysDtos)
	: RefCustomerToBookingsCommand(EntityKeyDto);

internal partial class UpdateRefCustomerToBookingsCommandHandler
	: RefCustomerToBookingsCommandHandlerBase<UpdateRefCustomerToBookingsCommand>
{
	public UpdateRefCustomerToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCustomerToBookingsCommand request)
    {
		var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.Booking>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCustomerRelatedBookings(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Booking", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
		entity.UpdateRefToBookings(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCustomerToBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCustomerToBookingsCommand(EntityKeyDto);

internal partial class DeleteRefCustomerToBookingsCommandHandler
	: RefCustomerToBookingsCommandHandlerBase<DeleteRefCustomerToBookingsCommand>
{
	public DeleteRefCustomerToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCustomerToBookingsCommand request)
    {
        var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomerRelatedBookings(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToBookings(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCustomerToBookingsCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToBookingsCommand(EntityKeyDto);

internal partial class DeleteAllRefCustomerToBookingsCommandHandler
	: RefCustomerToBookingsCommandHandlerBase<DeleteAllRefCustomerToBookingsCommand>
{
	public DeleteAllRefCustomerToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCustomerToBookingsCommand request)
    {
        var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
		entity.DeleteAllRefToBookings();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCustomerToBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToBookingsCommand
{
	public AppDbContext DbContext { get; }

	public RefCustomerToBookingsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<CustomerEntity?> GetCustomer(CustomerKeyDto entityKeyDto)
	{
		var keyId = Dto.CustomerMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Customers.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Booking?> GetCustomerRelatedBookings(BookingKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.BookingMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Bookings.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CustomerEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}