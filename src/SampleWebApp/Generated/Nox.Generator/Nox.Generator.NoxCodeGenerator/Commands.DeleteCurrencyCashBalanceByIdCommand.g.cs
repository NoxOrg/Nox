﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Commands;

public record DeleteCurrencyCashBalanceByIdCommand(System.String keyStoreId, System.UInt32 keyCurrencyId) : IRequest<bool>;

public class DeleteCurrencyCashBalanceByIdCommandHandler: CommandBase, IRequestHandler<DeleteCurrencyCashBalanceByIdCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }

    public  DeleteCurrencyCashBalanceByIdCommandHandler(
        SampleWebAppDbContext dbContext,
        NoxSolution noxSolution, 
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }    

    public async Task<bool> Handle(DeleteCurrencyCashBalanceByIdCommand request, CancellationToken cancellationToken)
    {
        var keyStoreId = CreateNoxTypeForKey<CurrencyCashBalance,Text>("StoreId", request.keyStoreId);
        var keyCurrencyId = CreateNoxTypeForKey<CurrencyCashBalance,Nuid>("CurrencyId", request.keyCurrencyId);

        var entity = await DbContext.CurrencyCashBalances.FindAsync(keyStoreId, keyCurrencyId);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}