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

public record UpdateStoreSecurityPasswordsCommand(System.String keyId, StoreSecurityPasswordsUpdateDto EntityDto) : IRequest<bool>;

public class UpdateStoreSecurityPasswordsCommandHandler: CommandBase, IRequestHandler<UpdateStoreSecurityPasswordsCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<StoreSecurityPasswords> EntityMapper { get; }

    public  UpdateStoreSecurityPasswordsCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<StoreSecurityPasswords> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(UpdateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.keyId);
    
        var entity = await DbContext.StoreSecurityPasswords.FindAsync(keyId);
        if (entity == null)
        {
            return false;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<StoreSecurityPasswords>(), request.EntityDto);
        //entity.Updated();

        // Todo map dto
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return result > 0;        
    }
}