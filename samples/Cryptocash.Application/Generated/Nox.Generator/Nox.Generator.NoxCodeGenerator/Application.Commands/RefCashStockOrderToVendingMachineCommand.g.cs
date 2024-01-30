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

public abstract record RefCashStockOrderToVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCashStockOrderToVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToVendingMachineCommand(EntityKeyDto);

internal partial class CreateRefCashStockOrderToVendingMachineCommandHandler
	: RefCashStockOrderToVendingMachineCommandHandlerBase<CreateRefCashStockOrderToVendingMachineCommand>
{
	public CreateRefCashStockOrderToVendingMachineCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCashStockOrderToVendingMachineCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCashStockOrder(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCashStockOrderForVendingMachine(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToVendingMachine(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCashStockOrderToVendingMachineCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCashStockOrder(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCashStockOrderForVendingMachine(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToVendingMachine(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCashStockOrderToVendingMachineCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCashStockOrder(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("CashStockOrder",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToVendingMachine();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCashStockOrderToVendingMachineCommandHandlerBase<TRequest> : CommandBase<TRequest, CashStockOrderEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCashStockOrderToVendingMachineCommand
{
	public IRepository Repository { get; }

	public RefCashStockOrderToVendingMachineCommandHandlerBase(
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
		return await Repository.FindAsync<CashStockOrder>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.VendingMachine?> GetCashStockOrderForVendingMachine(VendingMachineKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.VendingMachineMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<VendingMachine>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CashStockOrderEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}