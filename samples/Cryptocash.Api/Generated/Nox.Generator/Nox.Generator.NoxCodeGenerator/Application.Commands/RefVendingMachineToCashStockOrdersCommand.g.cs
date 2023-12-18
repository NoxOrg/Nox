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
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public abstract record RefVendingMachineToCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefVendingMachineToCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToCashStockOrdersCommand(EntityKeyDto);

internal partial class CreateRefVendingMachineToCashStockOrdersCommandHandler
	: RefVendingMachineToCashStockOrdersCommandHandlerBase<CreateRefVendingMachineToCashStockOrdersCommand>
{
	public CreateRefVendingMachineToCashStockOrdersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefVendingMachineToCashStockOrdersCommand request)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCashStockOrder(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("CashStockOrder",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCashStockOrders(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefVendingMachineToCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto, List<CashStockOrderKeyDto> RelatedEntitiesKeysDtos)
	: RefVendingMachineToCashStockOrdersCommand(EntityKeyDto);

internal partial class UpdateRefVendingMachineToCashStockOrdersCommandHandler
	: RefVendingMachineToCashStockOrdersCommandHandlerBase<UpdateRefVendingMachineToCashStockOrdersCommand>
{
	public UpdateRefVendingMachineToCashStockOrdersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefVendingMachineToCashStockOrdersCommand request)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.CashStockOrder>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCashStockOrder(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("CashStockOrder", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.CashStockOrders).LoadAsync();
		entity.UpdateRefToCashStockOrders(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefVendingMachineToCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToCashStockOrdersCommand(EntityKeyDto);

internal partial class DeleteRefVendingMachineToCashStockOrdersCommandHandler
	: RefVendingMachineToCashStockOrdersCommandHandlerBase<DeleteRefVendingMachineToCashStockOrdersCommand>
{
	public DeleteRefVendingMachineToCashStockOrdersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefVendingMachineToCashStockOrdersCommand request)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCashStockOrder(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("CashStockOrder", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCashStockOrders(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefVendingMachineToCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToCashStockOrdersCommand(EntityKeyDto);

internal partial class DeleteAllRefVendingMachineToCashStockOrdersCommandHandler
	: RefVendingMachineToCashStockOrdersCommandHandlerBase<DeleteAllRefVendingMachineToCashStockOrdersCommand>
{
	public DeleteAllRefVendingMachineToCashStockOrdersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefVendingMachineToCashStockOrdersCommand request)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.CashStockOrders).LoadAsync();
		entity.DeleteAllRefToCashStockOrders();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefVendingMachineToCashStockOrdersCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToCashStockOrdersCommand
{
	public AppDbContext DbContext { get; }

	public RefVendingMachineToCashStockOrdersCommandHandlerBase(
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

	protected async Task<VendingMachineEntity?> GetVendingMachine(VendingMachineKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.VendingMachines.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.CashStockOrder?> GetCashStockOrder(CashStockOrderKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.CashStockOrderMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.CashStockOrders.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, VendingMachineEntity entity)
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