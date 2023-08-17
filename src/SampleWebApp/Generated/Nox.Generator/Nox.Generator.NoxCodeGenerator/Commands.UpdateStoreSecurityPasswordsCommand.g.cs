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

public record UpdateStoreSecurityPasswordsCommand(System.String keyId, StoreSecurityPasswordsUpdateDto EntityDto) : IRequest<StoreSecurityPasswordsKeyDto?>;

public class UpdateStoreSecurityPasswordsCommandHandler: CommandBase, IRequestHandler<UpdateStoreSecurityPasswordsCommand, StoreSecurityPasswordsKeyDto?>
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
    
    public async Task<StoreSecurityPasswordsKeyDto?> Handle(UpdateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.keyId);
    
        var entity = await DbContext.StoreSecurityPasswords.FindAsync(keyId);
        if (entity == null)
        {
            return null;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<StoreSecurityPasswords>(), request.EntityDto);
        
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return new StoreSecurityPasswordsKeyDto(entity.Id.Value);
    }
}