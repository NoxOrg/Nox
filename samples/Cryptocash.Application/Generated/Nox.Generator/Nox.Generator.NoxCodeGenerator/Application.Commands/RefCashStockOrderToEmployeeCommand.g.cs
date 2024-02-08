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
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public abstract record RefCashStockOrderToEmployeeCommand(CashStockOrderKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCashStockOrderToEmployeeCommand(CashStockOrderKeyDto EntityKeyDto, EmployeeKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToEmployeeCommand(EntityKeyDto);

internal partial class CreateRefCashStockOrderToEmployeeCommandHandler
	: RefCashStockOrderToEmployeeCommandHandlerBase<CreateRefCashStockOrderToEmployeeCommand>
{
	public CreateRefCashStockOrderToEmployeeCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCashStockOrderToEmployeeCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCashStockOrder(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCashStockOrderReviewedByEmployee(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Employee",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToEmployee(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefCashStockOrderToEmployeeCommand(CashStockOrderKeyDto EntityKeyDto, EmployeeKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToEmployeeCommand(EntityKeyDto);

internal partial class DeleteRefCashStockOrderToEmployeeCommandHandler
	: RefCashStockOrderToEmployeeCommandHandlerBase<DeleteRefCashStockOrderToEmployeeCommand>
{
	public DeleteRefCashStockOrderToEmployeeCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCashStockOrderToEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCashStockOrder(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCashStockOrderReviewedByEmployee(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Employee", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToEmployee(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCashStockOrderToEmployeeCommand(CashStockOrderKeyDto EntityKeyDto)
	: RefCashStockOrderToEmployeeCommand(EntityKeyDto);

internal partial class DeleteAllRefCashStockOrderToEmployeeCommandHandler
	: RefCashStockOrderToEmployeeCommandHandlerBase<DeleteAllRefCashStockOrderToEmployeeCommand>
{
	public DeleteAllRefCashStockOrderToEmployeeCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCashStockOrderToEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCashStockOrder(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToEmployee();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCashStockOrderToEmployeeCommandHandlerBase<TRequest> : CommandBase<TRequest, CashStockOrderEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCashStockOrderToEmployeeCommand
{
	public IRepository Repository { get; }

	public RefCashStockOrderToEmployeeCommandHandlerBase(
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

	protected async Task<CashStockOrderEntity?> GetCashStockOrder(CashStockOrderKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CashStockOrderMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<Cryptocash.Domain.CashStockOrder>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Employee?> GetCashStockOrderReviewedByEmployee(EmployeeKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.EmployeeMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Cryptocash.Domain.Employee>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CashStockOrderEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}