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

public abstract record RefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefCustomerToTransactionsCommand(EntityKeyDto);

internal partial class CreateRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<CreateRefCustomerToTransactionsCommand>
{
	public CreateRefCustomerToTransactionsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCustomerToTransactionsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomerRelatedTransactions(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Transaction",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTransactions(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto, List<TransactionKeyDto> RelatedEntitiesKeysDtos)
	: RefCustomerToTransactionsCommand(EntityKeyDto);

internal partial class UpdateRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<UpdateRefCustomerToTransactionsCommand>
{
	public UpdateRefCustomerToTransactionsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCustomerToTransactionsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.Transaction>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCustomerRelatedTransactions(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Transaction", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTransactions(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefCustomerToTransactionsCommand(EntityKeyDto);

internal partial class DeleteRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<DeleteRefCustomerToTransactionsCommand>
{
	public DeleteRefCustomerToTransactionsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCustomerToTransactionsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomerRelatedTransactions(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Transaction", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTransactions(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToTransactionsCommand(EntityKeyDto);

internal partial class DeleteAllRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<DeleteAllRefCustomerToTransactionsCommand>
{
	public DeleteAllRefCustomerToTransactionsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCustomerToTransactionsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTransactions();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCustomerToTransactionsCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToTransactionsCommand
{
	public IRepository Repository { get; }

	public RefCustomerToTransactionsCommandHandlerBase(
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
		return await Repository.FindAndIncludeAsync<Customer>(keys.ToArray(), x => x.Transactions, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Transaction?> GetCustomerRelatedTransactions(TransactionKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TransactionMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Transaction>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CustomerEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}