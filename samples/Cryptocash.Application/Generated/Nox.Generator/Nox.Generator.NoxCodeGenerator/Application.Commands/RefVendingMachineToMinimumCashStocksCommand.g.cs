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

public abstract record RefVendingMachineToMinimumCashStocksCommand(VendingMachineKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefVendingMachineToMinimumCashStocksCommand(VendingMachineKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToMinimumCashStocksCommand(EntityKeyDto);

internal partial class CreateRefVendingMachineToMinimumCashStocksCommandHandler
	: RefVendingMachineToMinimumCashStocksCommandHandlerBase<CreateRefVendingMachineToMinimumCashStocksCommand>
{
	public CreateRefVendingMachineToMinimumCashStocksCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefVendingMachineToMinimumCashStocksCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineRequiredMinimumCashStocks(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("MinimumCashStock",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToMinimumCashStocks(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefVendingMachineToMinimumCashStocksCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.MinimumCashStock>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetVendingMachineRequiredMinimumCashStocks(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("MinimumCashStock", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToMinimumCashStocks(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefVendingMachineToMinimumCashStocksCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineRequiredMinimumCashStocks(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("MinimumCashStock", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToMinimumCashStocks(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefVendingMachineToMinimumCashStocksCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToMinimumCashStocks();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefVendingMachineToMinimumCashStocksCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToMinimumCashStocksCommand
{
	public IRepository Repository { get; }

	public RefVendingMachineToMinimumCashStocksCommandHandlerBase(
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
		return await Repository.FindAndIncludeAsync<Cryptocash.Domain.VendingMachine>(keys.ToArray(), x => x.MinimumCashStocks, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.MinimumCashStock?> GetVendingMachineRequiredMinimumCashStocks(MinimumCashStockKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.MinimumCashStockMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Cryptocash.Domain.MinimumCashStock>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, VendingMachineEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}