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

public record UpdateStoreCommand(System.String keyId, StoreUpdateDto EntityDto) : IRequest<bool>;

public class UpdateStoreCommandHandler: CommandBase, IRequestHandler<UpdateStoreCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<Store> EntityMapper { get; }

    public  UpdateStoreCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<Store> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<Store,Text>("Id", request.keyId);
    
        var entity = await DbContext.Stores.FindAsync(keyId);
        if (entity == null)
        {
            return false;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<Store>(), request.EntityDto);
        
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return result > 0;        
    }
}