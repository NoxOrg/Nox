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

public abstract record RefTransactionToCustomerCommand(TransactionKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTransactionToCustomerCommand(TransactionKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefTransactionToCustomerCommand(EntityKeyDto);

internal partial class CreateRefTransactionToCustomerCommandHandler
	: RefTransactionToCustomerCommandHandlerBase<CreateRefTransactionToCustomerCommand>
{
	public CreateRefTransactionToCustomerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTransactionToCustomerCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTransaction(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTransactionForCustomer(request.RelatedEntityKeyDto, cancellationToken);
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

public record DeleteRefTransactionToCustomerCommand(TransactionKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefTransactionToCustomerCommand(EntityKeyDto);

internal partial class DeleteRefTransactionToCustomerCommandHandler
	: RefTransactionToCustomerCommandHandlerBase<DeleteRefTransactionToCustomerCommand>
{
	public DeleteRefTransactionToCustomerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTransactionToCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTransaction(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTransactionForCustomer(request.RelatedEntityKeyDto, cancellationToken);
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

public record DeleteAllRefTransactionToCustomerCommand(TransactionKeyDto EntityKeyDto)
	: RefTransactionToCustomerCommand(EntityKeyDto);

internal partial class DeleteAllRefTransactionToCustomerCommandHandler
	: RefTransactionToCustomerCommandHandlerBase<DeleteAllRefTransactionToCustomerCommand>
{
	public DeleteAllRefTransactionToCustomerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTransactionToCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTransaction(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCustomer();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTransactionToCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, TransactionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTransactionToCustomerCommand
{
	public IRepository Repository { get; }

	public RefTransactionToCustomerCommandHandlerBase(
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
		return await Repository.FindAsync<Cryptocash.Domain.Transaction>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Customer?> GetTransactionForCustomer(CustomerKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CustomerMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Cryptocash.Domain.Customer>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TransactionEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}