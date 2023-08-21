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

public record PartialUpdateStoreSecurityPasswordsCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<bool>;

public class PartialUpdateStoreSecurityPasswordsCommandHandler: CommandBase, IRequestHandler<PartialUpdateStoreSecurityPasswordsCommand, bool>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<StoreSecurityPasswords> EntityMapper { get; }

    public PartialUpdateStoreSecurityPasswordsCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<StoreSecurityPasswords> entityMapper,
        IUserProvider userProvider,
        ISystemProvider systemProvider) : base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<bool> Handle(PartialUpdateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.keyId);
    
        var entity = await DbContext.StoreSecurityPasswords.FindAsync(keyId);
        if (entity == null)
        {
            return false;
        }
        //EntityMapper.MapToEntity(entity, GetEntityDefinition<StoreSecurityPasswords>(), request.EntityDto);
        
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