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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefVendingMachineToCashStockOrdersCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineRelatedCashStockOrders(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("CashStockOrder",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCashStockOrders(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefVendingMachineToCashStockOrdersCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.CashStockOrder>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetVendingMachineRelatedCashStockOrders(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("CashStockOrder", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToCashStockOrders(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefVendingMachineToCashStockOrdersCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineRelatedCashStockOrders(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("CashStockOrder", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCashStockOrders(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefVendingMachineToCashStockOrdersCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCashStockOrders();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefVendingMachineToCashStockOrdersCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToCashStockOrdersCommand
{
	public IRepository Repository { get; }

	public RefVendingMachineToCashStockOrdersCommandHandlerBase(
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

	protected async Task<VendingMachineEntity?> GetVendingMachine(VendingMachineKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.VendingMachineMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<VendingMachine>(keys.ToArray(), x => x.CashStockOrders, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.CashStockOrder?> GetVendingMachineRelatedCashStockOrders(CashStockOrderKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CashStockOrderMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<CashStockOrder>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, VendingMachineEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}