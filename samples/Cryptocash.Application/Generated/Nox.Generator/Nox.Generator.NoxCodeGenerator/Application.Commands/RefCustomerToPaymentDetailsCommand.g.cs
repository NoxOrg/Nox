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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCustomerToPaymentDetailsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomerRelatedPaymentDetails(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("PaymentDetail",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToPaymentDetails(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCustomerToPaymentDetailsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.PaymentDetail>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCustomerRelatedPaymentDetails(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("PaymentDetail", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToPaymentDetails(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCustomerToPaymentDetailsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomerRelatedPaymentDetails(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("PaymentDetail", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToPaymentDetails(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCustomerToPaymentDetailsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToPaymentDetails();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCustomerToPaymentDetailsCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToPaymentDetailsCommand
{
	public IRepository Repository { get; }

	public RefCustomerToPaymentDetailsCommandHandlerBase(
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

	protected async Task<CustomerEntity?> GetCustomer(CustomerKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CustomerMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Customer>(keys.ToArray(), x => x.PaymentDetails, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.PaymentDetail?> GetCustomerRelatedPaymentDetails(PaymentDetailKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.PaymentDetailMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<PaymentDetail>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CustomerEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}