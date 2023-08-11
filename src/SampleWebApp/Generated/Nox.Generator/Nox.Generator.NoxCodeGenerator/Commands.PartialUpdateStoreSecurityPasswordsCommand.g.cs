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

public record PartialUpdateStoreSecurityPasswordsCommand(System.String key, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<bool>;

public class PartialUpdateStoreSecurityPasswordsCommandHandler: CommandBase, IRequestHandler<PartialUpdateStoreSecurityPasswordsCommand, bool>
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
    
    public async Task<bool> Handle(PartialUpdateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.StoreSecurityPasswords.FindAsync(CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.key));
        if (entity == null)
        {
            return false;
        }
        //EntityMapper.MapToEntity(entity, GetEntityDefinition<StoreSecurityPasswords>(), request.EntityDto);
        //// Todo map dto
        //DbContext.Entry(entity).State = EntityState.Modified;
        //var result = await DbContext.SaveChangesAsync();             
        //return result > 0;        
        return true;
    }
}