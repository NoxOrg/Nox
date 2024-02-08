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
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public abstract record RefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCommissionToBookingsCommand(EntityKeyDto);

internal partial class CreateRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<CreateRefCommissionToBookingsCommand>
{
	public CreateRefCommissionToBookingsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCommissionToBookingsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCommission(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCommissionFeesForBooking(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToBookings(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto, List<BookingKeyDto> RelatedEntitiesKeysDtos)
	: RefCommissionToBookingsCommand(EntityKeyDto);

internal partial class UpdateRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<UpdateRefCommissionToBookingsCommand>
{
	public UpdateRefCommissionToBookingsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCommissionToBookingsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCommission(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.Booking>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCommissionFeesForBooking(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Booking", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToBookings(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCommissionToBookingsCommand(EntityKeyDto);

internal partial class DeleteRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<DeleteRefCommissionToBookingsCommand>
{
	public DeleteRefCommissionToBookingsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCommissionToBookingsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCommission(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCommissionFeesForBooking(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToBookings(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto)
	: RefCommissionToBookingsCommand(EntityKeyDto);

internal partial class DeleteAllRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<DeleteAllRefCommissionToBookingsCommand>
{
	public DeleteAllRefCommissionToBookingsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCommissionToBookingsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCommission(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToBookings();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCommissionToBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, CommissionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCommissionToBookingsCommand
{
	public IRepository Repository { get; }

	public RefCommissionToBookingsCommandHandlerBase(
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

	protected async Task<CommissionEntity?> GetCommission(CommissionKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CommissionMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Cryptocash.Domain.Commission>(keys.ToArray(), x => x.Bookings, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Booking?> GetCommissionFeesForBooking(BookingKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.BookingMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Cryptocash.Domain.Booking>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CommissionEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}