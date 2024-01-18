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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefMinimumCashStockToVendingMachinesCommand request)
    {
		var entity = await GetMinimumCashStock(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetMinimumCashStocksRequiredByVendingMachines(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToVendingMachines(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefMinimumCashStockToVendingMachinesCommand request)
    {
		var entity = await GetMinimumCashStock(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.VendingMachine>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetMinimumCashStocksRequiredByVendingMachines(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("VendingMachine", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
		entity.UpdateRefToVendingMachines(relatedEntities);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefMinimumCashStockToVendingMachinesCommand request)
    {
        var entity = await GetMinimumCashStock(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetMinimumCashStocksRequiredByVendingMachines(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToVendingMachines(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefMinimumCashStockToVendingMachinesCommand request)
    {
        var entity = await GetMinimumCashStock(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
		entity.DeleteAllRefToVendingMachines();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefMinimumCashStockToVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, MinimumCashStockEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefMinimumCashStockToVendingMachinesCommand
{
	public AppDbContext DbContext { get; }

	public RefMinimumCashStockToVendingMachinesCommandHandlerBase(
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

	protected async Task<MinimumCashStockEntity?> GetMinimumCashStock(MinimumCashStockKeyDto entityKeyDto)
	{
		var keyId = Dto.MinimumCashStockMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.MinimumCashStocks.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.VendingMachine?> GetMinimumCashStocksRequiredByVendingMachines(VendingMachineKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.VendingMachineMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.VendingMachines.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, MinimumCashStockEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}