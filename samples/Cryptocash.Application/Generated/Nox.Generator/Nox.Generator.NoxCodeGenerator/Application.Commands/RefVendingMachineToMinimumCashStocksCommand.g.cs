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
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public abstract record RefVendingMachineToMinimumCashStocksCommand(VendingMachineKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefVendingMachineToMinimumCashStocksCommand(VendingMachineKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToMinimumCashStocksCommand(EntityKeyDto);

internal partial class CreateRefVendingMachineToMinimumCashStocksCommandHandler
	: RefVendingMachineToMinimumCashStocksCommandHandlerBase<CreateRefVendingMachineToMinimumCashStocksCommand>
{
	public CreateRefVendingMachineToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefVendingMachineToMinimumCashStocksCommand request)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineRequiredMinimumCashStocks(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("MinimumCashStock",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToMinimumCashStocks(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefVendingMachineToMinimumCashStocksCommand(VendingMachineKeyDto EntityKeyDto, List<MinimumCashStockKeyDto> RelatedEntitiesKeysDtos)
	: RefVendingMachineToMinimumCashStocksCommand(EntityKeyDto);

internal partial class UpdateRefVendingMachineToMinimumCashStocksCommandHandler
	: RefVendingMachineToMinimumCashStocksCommandHandlerBase<UpdateRefVendingMachineToMinimumCashStocksCommand>
{
	public UpdateRefVendingMachineToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefVendingMachineToMinimumCashStocksCommand request)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.MinimumCashStock>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetVendingMachineRequiredMinimumCashStocks(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("MinimumCashStock", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.MinimumCashStocks).LoadAsync();
		entity.UpdateRefToMinimumCashStocks(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefVendingMachineToMinimumCashStocksCommand(VendingMachineKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToMinimumCashStocksCommand(EntityKeyDto);

internal partial class DeleteRefVendingMachineToMinimumCashStocksCommandHandler
	: RefVendingMachineToMinimumCashStocksCommandHandlerBase<DeleteRefVendingMachineToMinimumCashStocksCommand>
{
	public DeleteRefVendingMachineToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefVendingMachineToMinimumCashStocksCommand request)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineRequiredMinimumCashStocks(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("MinimumCashStock", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToMinimumCashStocks(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefVendingMachineToMinimumCashStocksCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToMinimumCashStocksCommand(EntityKeyDto);

internal partial class DeleteAllRefVendingMachineToMinimumCashStocksCommandHandler
	: RefVendingMachineToMinimumCashStocksCommandHandlerBase<DeleteAllRefVendingMachineToMinimumCashStocksCommand>
{
	public DeleteAllRefVendingMachineToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefVendingMachineToMinimumCashStocksCommand request)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.MinimumCashStocks).LoadAsync();
		entity.DeleteAllRefToMinimumCashStocks();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefVendingMachineToMinimumCashStocksCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToMinimumCashStocksCommand
{
	public AppDbContext DbContext { get; }

	public RefVendingMachineToMinimumCashStocksCommandHandlerBase(
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
		var keyId = Dto.VendingMachineMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.VendingMachines.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.MinimumCashStock?> GetVendingMachineRequiredMinimumCashStocks(MinimumCashStockKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.MinimumCashStockMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.MinimumCashStocks.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, VendingMachineEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}