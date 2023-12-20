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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefEmployeeToCashStockOrderCommand request)
    {
		var entity = await GetEmployee(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Employee",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCashStockOrder(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("CashStockOrder",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCashStockOrder(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefEmployeeToCashStockOrderCommand request)
    {
        var entity = await GetEmployee(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Employee",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCashStockOrder(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("CashStockOrder", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCashStockOrder(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefEmployeeToCashStockOrderCommand request)
    {
        var entity = await GetEmployee(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Employee",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCashStockOrder();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefEmployeeToCashStockOrderCommandHandlerBase<TRequest> : CommandBase<TRequest, EmployeeEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefEmployeeToCashStockOrderCommand
{
	public AppDbContext DbContext { get; }

	public RefEmployeeToCashStockOrderCommandHandlerBase(
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

	protected async Task<EmployeeEntity?> GetEmployee(EmployeeKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Employees.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.CashStockOrder?> GetCashStockOrder(CashStockOrderKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.CashStockOrderMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.CashStockOrders.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, EmployeeEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}