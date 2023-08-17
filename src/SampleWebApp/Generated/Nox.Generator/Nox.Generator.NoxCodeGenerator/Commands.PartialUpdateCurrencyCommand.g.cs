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

public record PartialUpdateCurrencyCommand(System.UInt32 keyId, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<CurrencyKeyDto?>;

public class PartialUpdateCurrencyCommandHandler: CommandBase, IRequestHandler<PartialUpdateCurrencyCommand, CurrencyKeyDto?>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<Currency> EntityMapper { get; }

    public PartialUpdateCurrencyCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<Currency> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<CurrencyKeyDto?> Handle(PartialUpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<Currency,Nuid>("Id", request.keyId);
    
        var entity = await DbContext.Currencies.FindAsync(keyId);
        if (entity == null)
        {
            return null;
        }
        //EntityMapper.MapToEntity(entity, GetEntityDefinition<Currency>(), request.EntityDto);
        //// Todo map dto
        //DbContext.Entry(entity).State = EntityState.Modified;
        //var result = await DbContext.SaveChangesAsync();             
        //return result > 0;        
        return new CurrencyKeyDto(entity.Id.Value);
    }
}