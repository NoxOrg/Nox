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

public record PartialUpdateStoreSecurityPasswordsCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<StoreSecurityPasswordsKeyDto?>;

public class PartialUpdateStoreSecurityPasswordsCommandHandler: CommandBase, IRequestHandler<PartialUpdateStoreSecurityPasswordsCommand, StoreSecurityPasswordsKeyDto?>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<StoreSecurityPasswords> EntityMapper { get; }

    public PartialUpdateStoreSecurityPasswordsCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<StoreSecurityPasswords> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<StoreSecurityPasswordsKeyDto?> Handle(PartialUpdateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.keyId);
    
        var entity = await DbContext.StoreSecurityPasswords.FindAsync(keyId);
        if (entity == null)
        {
            return null;
        }
        EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<StoreSecurityPasswords>(), request.UpdatedProperties, request.DeletedPropertyNames);

        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();
        return new StoreSecurityPasswordsKeyDto(entity.Id.Value);
    }
}