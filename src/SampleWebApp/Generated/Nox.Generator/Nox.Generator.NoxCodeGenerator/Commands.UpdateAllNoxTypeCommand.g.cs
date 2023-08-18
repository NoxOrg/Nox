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

public record UpdateAllNoxTypeCommand(System.Int64 keyId, System.String keyTextId, AllNoxTypeUpdateDto EntityDto) : IRequest<bool>;

public class UpdateAllNoxTypeCommandHandler: CommandBase, IRequestHandler<UpdateAllNoxTypeCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<AllNoxType> EntityMapper { get; }

    public  UpdateAllNoxTypeCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<AllNoxType> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(UpdateAllNoxTypeCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<AllNoxType,DatabaseNumber>("Id", request.keyId);
        var keyTextId = CreateNoxTypeForKey<AllNoxType,Text>("TextId", request.keyTextId);
    
        var entity = await DbContext.AllNoxTypes.FindAsync(keyId, keyTextId);
        if (entity == null)
        {
            return false;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<AllNoxType>(), request.EntityDto);
        //entity.Updated();

        // Todo map dto
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return result > 0;        
    }
}