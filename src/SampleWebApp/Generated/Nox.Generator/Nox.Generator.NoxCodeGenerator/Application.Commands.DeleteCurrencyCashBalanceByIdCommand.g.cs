﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using CurrencyCashBalance = SampleWebApp.Domain.CurrencyCashBalance;

namespace SampleWebApp.Application.Commands;

public record DeleteCurrencyCashBalanceByIdCommand(System.String keyStoreId, System.UInt32 keyCurrencyId, System.Guid? Etag) : IRequest<bool>;

public class DeleteCurrencyCashBalanceByIdCommandHandler: CommandBase<DeleteCurrencyCashBalanceByIdCommand,CurrencyCashBalance>, IRequestHandler<DeleteCurrencyCashBalanceByIdCommand, bool>
{
	public SampleWebAppDbContext DbContext { get; }

	public DeleteCurrencyCashBalanceByIdCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteCurrencyCashBalanceByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyStoreId = CreateNoxTypeForKey<CurrencyCashBalance,Text>("StoreId", request.keyStoreId);
		var keyCurrencyId = CreateNoxTypeForKey<CurrencyCashBalance,Nuid>("CurrencyId", request.keyCurrencyId);

		var entity = await DbContext.CurrencyCashBalances.FindAsync(keyStoreId, keyCurrencyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;

		OnCompleted(entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}