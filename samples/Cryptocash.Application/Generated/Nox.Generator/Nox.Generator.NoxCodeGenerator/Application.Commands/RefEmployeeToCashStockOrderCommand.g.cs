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
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public abstract record RefEmployeeToCashStockOrderCommand(EmployeeKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefEmployeeToCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefEmployeeToCashStockOrderCommand(EntityKeyDto);

internal partial class CreateRefEmployeeToCashStockOrderCommandHandler
	: RefEmployeeToCashStockOrderCommandHandlerBase<CreateRefEmployeeToCashStockOrderCommand>
{
	public CreateRefEmployeeToCashStockOrderCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefEmployeeToCashStockOrderCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetEmployee(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Employee",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetEmployeeReviewingCashStockOrder(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("CashStockOrder",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCashStockOrder(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefEmployeeToCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefEmployeeToCashStockOrderCommand(EntityKeyDto);

internal partial class DeleteRefEmployeeToCashStockOrderCommandHandler
	: RefEmployeeToCashStockOrderCommandHandlerBase<DeleteRefEmployeeToCashStockOrderCommand>
{
	public DeleteRefEmployeeToCashStockOrderCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefEmployeeToCashStockOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetEmployee(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Employee",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetEmployeeReviewingCashStockOrder(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("CashStockOrder", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCashStockOrder(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefEmployeeToCashStockOrderCommand(EmployeeKeyDto EntityKeyDto)
	: RefEmployeeToCashStockOrderCommand(EntityKeyDto);

internal partial class DeleteAllRefEmployeeToCashStockOrderCommandHandler
	: RefEmployeeToCashStockOrderCommandHandlerBase<DeleteAllRefEmployeeToCashStockOrderCommand>
{
	public DeleteAllRefEmployeeToCashStockOrderCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefEmployeeToCashStockOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetEmployee(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Employee",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCashStockOrder();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefEmployeeToCashStockOrderCommandHandlerBase<TRequest> : CommandBase<TRequest, EmployeeEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefEmployeeToCashStockOrderCommand
{
	public IRepository Repository { get; }

	public RefEmployeeToCashStockOrderCommandHandlerBase(
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

	protected async Task<EmployeeEntity?> GetEmployee(EmployeeKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.EmployeeMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<Employee>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.CashStockOrder?> GetEmployeeReviewingCashStockOrder(CashStockOrderKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CashStockOrderMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<CashStockOrder>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, EmployeeEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}