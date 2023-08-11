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

public record UpdateCurrencyCommand(System.UInt32 keyId, CurrencyUpdateDto EntityDto) : IRequest<bool>;

public class UpdateCurrencyCommandHandler: CommandBase, IRequestHandler<UpdateCurrencyCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<Currency> EntityMapper { get; }

    public  UpdateCurrencyCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<Currency> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<Currency,Nuid>("Id", request.keyId);
    
        var entity = await DbContext.Currencies.FindAsync(keyId);
        if (entity == null)
        {
            return false;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<Currency>(), request.EntityDto);
        // Todo map dto
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return result > 0;        
    }
}