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
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public abstract record RefMinimumCashStockToVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefMinimumCashStockToVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToVendingMachinesCommand(EntityKeyDto);

internal partial class CreateRefMinimumCashStockToVendingMachinesCommandHandler
	: RefMinimumCashStockToVendingMachinesCommandHandlerBase<CreateRefMinimumCashStockToVendingMachinesCommand>
{
	public CreateRefMinimumCashStockToVendingMachinesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefMinimumCashStockToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetMinimumCashStock(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetMinimumCashStocksRequiredByVendingMachines(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToVendingMachines(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefMinimumCashStockToVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, List<VendingMachineKeyDto> RelatedEntitiesKeysDtos)
	: RefMinimumCashStockToVendingMachinesCommand(EntityKeyDto);

internal partial class UpdateRefMinimumCashStockToVendingMachinesCommandHandler
	: RefMinimumCashStockToVendingMachinesCommandHandlerBase<UpdateRefMinimumCashStockToVendingMachinesCommand>
{
	public UpdateRefMinimumCashStockToVendingMachinesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefMinimumCashStockToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetMinimumCashStock(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.VendingMachine>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetMinimumCashStocksRequiredByVendingMachines(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("VendingMachine", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToVendingMachines(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefMinimumCashStockToVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToVendingMachinesCommand(EntityKeyDto);

internal partial class DeleteRefMinimumCashStockToVendingMachinesCommandHandler
	: RefMinimumCashStockToVendingMachinesCommandHandlerBase<DeleteRefMinimumCashStockToVendingMachinesCommand>
{
	public DeleteRefMinimumCashStockToVendingMachinesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefMinimumCashStockToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetMinimumCashStock(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetMinimumCashStocksRequiredByVendingMachines(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToVendingMachines(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefMinimumCashStockToVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto)
	: RefMinimumCashStockToVendingMachinesCommand(EntityKeyDto);

internal partial class DeleteAllRefMinimumCashStockToVendingMachinesCommandHandler
	: RefMinimumCashStockToVendingMachinesCommandHandlerBase<DeleteAllRefMinimumCashStockToVendingMachinesCommand>
{
	public DeleteAllRefMinimumCashStockToVendingMachinesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefMinimumCashStockToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetMinimumCashStock(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToVendingMachines();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefMinimumCashStockToVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, MinimumCashStockEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefMinimumCashStockToVendingMachinesCommand
{
	public IRepository Repository { get; }

	public RefMinimumCashStockToVendingMachinesCommandHandlerBase(
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

	protected async Task<MinimumCashStockEntity?> GetMinimumCashStock(MinimumCashStockKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.MinimumCashStockMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Cryptocash.Domain.MinimumCashStock>(keys.ToArray(), x => x.VendingMachines, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.VendingMachine?> GetMinimumCashStocksRequiredByVendingMachines(VendingMachineKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.VendingMachineMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Cryptocash.Domain.VendingMachine>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, MinimumCashStockEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}