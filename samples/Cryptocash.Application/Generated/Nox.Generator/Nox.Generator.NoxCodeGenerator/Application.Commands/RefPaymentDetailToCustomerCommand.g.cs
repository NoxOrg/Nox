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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefPaymentDetailToCustomerCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetPaymentDetail(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPaymentDetailsUsedByCustomer(request.RelatedEntityKeyDto, cancellationToken);
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

public record DeleteRefPaymentDetailToCustomerCommand(PaymentDetailKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToCustomerCommand(EntityKeyDto);

internal partial class DeleteRefPaymentDetailToCustomerCommandHandler
	: RefPaymentDetailToCustomerCommandHandlerBase<DeleteRefPaymentDetailToCustomerCommand>
{
	public DeleteRefPaymentDetailToCustomerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefPaymentDetailToCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetPaymentDetail(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPaymentDetailsUsedByCustomer(request.RelatedEntityKeyDto, cancellationToken);
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

public record DeleteAllRefPaymentDetailToCustomerCommand(PaymentDetailKeyDto EntityKeyDto)
	: RefPaymentDetailToCustomerCommand(EntityKeyDto);

internal partial class DeleteAllRefPaymentDetailToCustomerCommandHandler
	: RefPaymentDetailToCustomerCommandHandlerBase<DeleteAllRefPaymentDetailToCustomerCommand>
{
	public DeleteAllRefPaymentDetailToCustomerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefPaymentDetailToCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetPaymentDetail(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCustomer();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefPaymentDetailToCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentDetailEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentDetailToCustomerCommand
{
	public IRepository Repository { get; }

	public RefPaymentDetailToCustomerCommandHandlerBase(
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

	protected async Task<PaymentDetailEntity?> GetPaymentDetail(PaymentDetailKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.PaymentDetailMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<PaymentDetail>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Customer?> GetPaymentDetailsUsedByCustomer(CustomerKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CustomerMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Customer>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, PaymentDetailEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}