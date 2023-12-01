
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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public abstract record RefCustomerToPaymentDetailsCommand(CustomerKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCustomerToPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefCustomerToPaymentDetailsCommand(EntityKeyDto);

internal partial class CreateRefCustomerToPaymentDetailsCommandHandler
	: RefCustomerToPaymentDetailsCommandHandlerBase<CreateRefCustomerToPaymentDetailsCommand>
{
	public CreateRefCustomerToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCustomerToPaymentDetailsCommand request)
    {
		var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetPaymentDetail(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToPaymentDetails(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCustomerToPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, List<PaymentDetailKeyDto> RelatedEntitiesKeysDtos)
	: RefCustomerToPaymentDetailsCommand(EntityKeyDto);

internal partial class UpdateRefCustomerToPaymentDetailsCommandHandler
	: RefCustomerToPaymentDetailsCommandHandlerBase<UpdateRefCustomerToPaymentDetailsCommand>
{
	public UpdateRefCustomerToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCustomerToPaymentDetailsCommand request)
    {
		var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<Cryptocash.Domain.PaymentDetail>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetPaymentDetail(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.PaymentDetails).LoadAsync();
		entity.UpdateRefToPaymentDetails(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCustomerToPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefCustomerToPaymentDetailsCommand(EntityKeyDto);

internal partial class DeleteRefCustomerToPaymentDetailsCommandHandler
	: RefCustomerToPaymentDetailsCommandHandlerBase<DeleteRefCustomerToPaymentDetailsCommand>
{
	public DeleteRefCustomerToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCustomerToPaymentDetailsCommand request)
    {
        var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetPaymentDetail(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToPaymentDetails(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCustomerToPaymentDetailsCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToPaymentDetailsCommand(EntityKeyDto);

internal partial class DeleteAllRefCustomerToPaymentDetailsCommandHandler
	: RefCustomerToPaymentDetailsCommandHandlerBase<DeleteAllRefCustomerToPaymentDetailsCommand>
{
	public DeleteAllRefCustomerToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCustomerToPaymentDetailsCommand request)
    {
        var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.PaymentDetails).LoadAsync();
		entity.DeleteAllRefToPaymentDetails();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCustomerToPaymentDetailsCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToPaymentDetailsCommand
{
	public AppDbContext DbContext { get; }

	public RefCustomerToPaymentDetailsCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Customers.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.PaymentDetail?> GetPaymentDetail(PaymentDetailKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.PaymentDetailMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.PaymentDetails.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CustomerEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}