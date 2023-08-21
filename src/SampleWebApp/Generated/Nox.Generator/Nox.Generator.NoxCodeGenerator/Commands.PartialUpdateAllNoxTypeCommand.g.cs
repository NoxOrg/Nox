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

public record PartialUpdateAllNoxTypeCommand(System.Int64 keyId, System.String keyTextId, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<bool>;

public class PartialUpdateAllNoxTypeCommandHandler: CommandBase, IRequestHandler<PartialUpdateAllNoxTypeCommand, bool>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<AllNoxType> EntityMapper { get; }

    public PartialUpdateAllNoxTypeCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<AllNoxType> entityMapper,
        IUserProvider userProvider,
        ISystemProvider systemProvider) : base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<bool> Handle(PartialUpdateAllNoxTypeCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<AllNoxType,DatabaseNumber>("Id", request.keyId);
        var keyTextId = CreateNoxTypeForKey<AllNoxType,Text>("TextId", request.keyTextId);
    
        var entity = await DbContext.AllNoxTypes.FindAsync(keyId, keyTextId);
        if (entity == null)
        {
            return false;
        }
        //EntityMapper.MapToEntity(entity, GetEntityDefinition<AllNoxType>(), request.EntityDto);
        
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