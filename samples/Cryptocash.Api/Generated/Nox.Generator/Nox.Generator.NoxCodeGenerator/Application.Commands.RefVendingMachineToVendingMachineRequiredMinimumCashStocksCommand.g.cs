﻿
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;

public abstract record RefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand(VendingMachineKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand(VendingMachineKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommandHandler: RefVendingMachineToVendingMachineRequiredMinimumCashStocksCommandHandlerBase<CreateRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand>
{
	public CreateRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand(VendingMachineKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommandHandler: RefVendingMachineToVendingMachineRequiredMinimumCashStocksCommandHandlerBase<DeleteRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand>
{
	public DeleteRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefVendingMachineToVendingMachineRequiredMinimumCashStocksCommandHandlerBase<TRequest>: CommandBase<TRequest, VendingMachine>, 
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefVendingMachineToVendingMachineRequiredMinimumCashStocksCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachine, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<MinimumCashStock, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.MinimumCashStocks.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToVendingMachineRequiredMinimumCashStocks(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToVendingMachineRequiredMinimumCashStocks(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}