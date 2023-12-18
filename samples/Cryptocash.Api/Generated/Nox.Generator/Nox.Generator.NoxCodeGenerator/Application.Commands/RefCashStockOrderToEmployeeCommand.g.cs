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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCashStockOrderToEmployeeCommand request)
    {
		var entity = await GetCashStockOrder(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetEmployee(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Employee",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToEmployee(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCashStockOrderToEmployeeCommand request)
    {
        var entity = await GetCashStockOrder(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetEmployee(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Employee", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToEmployee(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCashStockOrderToEmployeeCommand request)
    {
        var entity = await GetCashStockOrder(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToEmployee();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCashStockOrderToEmployeeCommandHandlerBase<TRequest> : CommandBase<TRequest, CashStockOrderEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCashStockOrderToEmployeeCommand
{
	public AppDbContext DbContext { get; }

	public RefCashStockOrderToEmployeeCommandHandlerBase(
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

	protected async Task<CashStockOrderEntity?> GetCashStockOrder(CashStockOrderKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.CashStockOrderMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.CashStockOrders.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Employee?> GetEmployee(EmployeeKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.EmployeeMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Employees.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CashStockOrderEntity entity)
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