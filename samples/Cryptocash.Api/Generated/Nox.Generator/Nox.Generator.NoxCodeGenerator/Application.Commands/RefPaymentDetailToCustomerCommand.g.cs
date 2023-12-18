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
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public abstract record RefPaymentDetailToCustomerCommand(PaymentDetailKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefPaymentDetailToCustomerCommand(PaymentDetailKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToCustomerCommand(EntityKeyDto);

internal partial class CreateRefPaymentDetailToCustomerCommandHandler
	: RefPaymentDetailToCustomerCommandHandlerBase<CreateRefPaymentDetailToCustomerCommand>
{
	public CreateRefPaymentDetailToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefPaymentDetailToCustomerCommand request)
    {
		var entity = await GetPaymentDetail(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomer(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Customer",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCustomer(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefPaymentDetailToCustomerCommand(PaymentDetailKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToCustomerCommand(EntityKeyDto);

internal partial class DeleteRefPaymentDetailToCustomerCommandHandler
	: RefPaymentDetailToCustomerCommandHandlerBase<DeleteRefPaymentDetailToCustomerCommand>
{
	public DeleteRefPaymentDetailToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefPaymentDetailToCustomerCommand request)
    {
        var entity = await GetPaymentDetail(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomer(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Customer", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCustomer(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefPaymentDetailToCustomerCommand(PaymentDetailKeyDto EntityKeyDto)
	: RefPaymentDetailToCustomerCommand(EntityKeyDto);

internal partial class DeleteAllRefPaymentDetailToCustomerCommandHandler
	: RefPaymentDetailToCustomerCommandHandlerBase<DeleteAllRefPaymentDetailToCustomerCommand>
{
	public DeleteAllRefPaymentDetailToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefPaymentDetailToCustomerCommand request)
    {
        var entity = await GetPaymentDetail(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCustomer();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefPaymentDetailToCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentDetailEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentDetailToCustomerCommand
{
	public AppDbContext DbContext { get; }

	public RefPaymentDetailToCustomerCommandHandlerBase(
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

	protected async Task<PaymentDetailEntity?> GetPaymentDetail(PaymentDetailKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.PaymentDetailMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.PaymentDetails.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Customer?> GetCustomer(CustomerKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.CustomerMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Customers.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, PaymentDetailEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}
		return true;
	}
}