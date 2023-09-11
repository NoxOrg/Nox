﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using CashStockOrder = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public record DeleteCashStockOrderByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteCashStockOrderByIdCommandHandler: CommandBase<DeleteCashStockOrderByIdCommand,CashStockOrder>, IRequestHandler<DeleteCashStockOrderByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteCashStockOrderByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteCashStockOrderByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CashStockOrder,AutoNumber>("Id", request.keyId);

		var entity = await DbContext.CashStockOrders.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}

		OnCompleted(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}