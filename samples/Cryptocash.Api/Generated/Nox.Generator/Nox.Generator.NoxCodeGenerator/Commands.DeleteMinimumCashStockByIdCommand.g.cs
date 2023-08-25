﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Commands;

public record DeleteMinimumCashStockByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteMinimumCashStockByIdCommandHandler: CommandBase<DeleteMinimumCashStockByIdCommand>, IRequestHandler<DeleteMinimumCashStockByIdCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public DeleteMinimumCashStockByIdCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteMinimumCashStockByIdCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<MinimumCashStock,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}