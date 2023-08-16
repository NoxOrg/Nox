﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;

public record PartialUpdateCurrencyCashBalanceCommand(System.String key, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<bool>;

public class PartialUpdateCurrencyCashBalanceCommandHandler: CommandBase, IRequestHandler<PartialUpdateCurrencyCashBalanceCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<CurrencyCashBalance> EntityMapper { get; }

    public PartialUpdateCurrencyCashBalanceCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<CurrencyCashBalance> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(PartialUpdateCurrencyCashBalanceCommand request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.CurrencyCashBalances.FindAsync(CreateNoxTypeForKey<CurrencyCashBalance,Text>("StoreId", request.key));
        if (entity == null)
        {
            return false;
        }
        //EntityMapper.MapToEntity(entity, GetEntityDefinition<CurrencyCashBalance>(), request.EntityDto);
        //// Todo map dto
        //DbContext.Entry(entity).State = EntityState.Modified;
        //var result = await DbContext.SaveChangesAsync();             
        //return result > 0;        
        return true;
    }
}