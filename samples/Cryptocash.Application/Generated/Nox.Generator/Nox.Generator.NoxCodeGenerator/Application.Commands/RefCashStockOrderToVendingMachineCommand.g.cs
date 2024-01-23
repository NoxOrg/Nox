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
using Dto = Cryptocash.Application.Dto;
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public abstract record RefCashStockOrderToVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCashStockOrderToVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToVendingMachineCommand(EntityKeyDto);

internal partial class CreateRefCashStockOrderToVendingMachineCommandHandler
	: RefCashStockOrderToVendingMachineCommandHandlerBase<CreateRefCashStockOrderToVendingMachineCommand>
{
	public CreateRefCashStockOrderToVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCashStockOrderToVendingMachineCommand request)
    {
		var entity = await GetCashStockOrder(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCashStockOrderForVendingMachine(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToVendingMachine(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefCashStockOrderToVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToVendingMachineCommand(EntityKeyDto);

internal partial class DeleteRefCashStockOrderToVendingMachineCommandHandler
	: RefCashStockOrderToVendingMachineCommandHandlerBase<DeleteRefCashStockOrderToVendingMachineCommand>
{
	public DeleteRefCashStockOrderToVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCashStockOrderToVendingMachineCommand request)
    {
        var entity = await GetCashStockOrder(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCashStockOrderForVendingMachine(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToVendingMachine(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCashStockOrderToVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto)
	: RefCashStockOrderToVendingMachineCommand(EntityKeyDto);

internal partial class DeleteAllRefCashStockOrderToVendingMachineCommandHandler
	: RefCashStockOrderToVendingMachineCommandHandlerBase<DeleteAllRefCashStockOrderToVendingMachineCommand>
{
	public DeleteAllRefCashStockOrderToVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCashStockOrderToVendingMachineCommand request)
    {
        var entity = await GetCashStockOrder(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToVendingMachine();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCashStockOrderToVendingMachineCommandHandlerBase<TRequest> : CommandBase<TRequest, CashStockOrderEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCashStockOrderToVendingMachineCommand
{
	public AppDbContext DbContext { get; }

	public RefCashStockOrderToVendingMachineCommandHandlerBase(
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
		var keyId = Dto.CashStockOrderMetadata.CreateId(entityKeyDto.keyId);		
		return await DbContext.CashStockOrders.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.VendingMachine?> GetCashStockOrderForVendingMachine(VendingMachineKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.VendingMachineMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.VendingMachines.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CashStockOrderEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}