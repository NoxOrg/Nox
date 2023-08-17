// Generated

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

public record UpdateCurrencyCashBalanceCommand(System.String keyStoreId, System.UInt32 keyCurrencyId, CurrencyCashBalanceUpdateDto EntityDto) : IRequest<CurrencyCashBalanceKeyDto?>;

public class UpdateCurrencyCashBalanceCommandHandler: CommandBase, IRequestHandler<UpdateCurrencyCashBalanceCommand, CurrencyCashBalanceKeyDto?>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<CurrencyCashBalance> EntityMapper { get; }

    public  UpdateCurrencyCashBalanceCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<CurrencyCashBalance> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<CurrencyCashBalanceKeyDto?> Handle(UpdateCurrencyCashBalanceCommand request, CancellationToken cancellationToken)
    {
        var keyStoreId = CreateNoxTypeForKey<CurrencyCashBalance,Text>("StoreId", request.keyStoreId);
        var keyCurrencyId = CreateNoxTypeForKey<CurrencyCashBalance,Nuid>("CurrencyId", request.keyCurrencyId);
    
        var entity = await DbContext.CurrencyCashBalances.FindAsync(keyStoreId, keyCurrencyId);
        if (entity == null)
        {
            return null;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<CurrencyCashBalance>(), request.EntityDto);
        
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return new CurrencyCashBalanceKeyDto(entity.StoreId.Value, entity.CurrencyId.Value);
    }
}