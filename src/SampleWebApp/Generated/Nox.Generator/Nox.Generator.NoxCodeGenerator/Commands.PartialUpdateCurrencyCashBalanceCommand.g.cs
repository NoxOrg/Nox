// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;

public record PartialUpdateCurrencyCashBalanceCommand(System.String keyStoreId, System.UInt32 keyCurrencyId, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<bool>;

public class PartialUpdateCurrencyCashBalanceCommandHandler: CommandBase, IRequestHandler<PartialUpdateCurrencyCashBalanceCommand, bool>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<CurrencyCashBalance> EntityMapper { get; }

    public PartialUpdateCurrencyCashBalanceCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<CurrencyCashBalance> entityMapper,
        IUserProvider userProvider,
        ISystemProvider systemProvider) : base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<bool> Handle(PartialUpdateCurrencyCashBalanceCommand request, CancellationToken cancellationToken)
    {
        var keyStoreId = CreateNoxTypeForKey<CurrencyCashBalance,Text>("StoreId", request.keyStoreId);
        var keyCurrencyId = CreateNoxTypeForKey<CurrencyCashBalance,Nuid>("CurrencyId", request.keyCurrencyId);
    
        var entity = await DbContext.CurrencyCashBalances.FindAsync(keyStoreId, keyCurrencyId);
        if (entity == null)
        {
            return false;
        }
        //EntityMapper.MapToEntity(entity, GetEntityDefinition<CurrencyCashBalance>(), request.EntityDto);
        
        var updatedBy = _userProvider.GetUser();
        var updatedVia = _systemProvider.GetSystem();
        entity.Updated(updatedBy, updatedVia);

        //// Todo map dto
        //DbContext.Entry(entity).State = EntityState.Modified;
        //var result = await DbContext.SaveChangesAsync();             
        //return result > 0;        
        return true;
    }
}