// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;

public record PartialUpdateClientDatabaseNumberCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, HashSet<string> DeletedPropertyNames) : IRequest <ClientDatabaseNumberKeyDto?>;

public class PartialUpdateClientDatabaseNumberCommandHandler: CommandBase, IRequestHandler<PartialUpdateClientDatabaseNumberCommand, ClientDatabaseNumberKeyDto?>
{
    public ClientApiDbContext DbContext { get; }    
    public IEntityMapper<ClientDatabaseNumber> EntityMapper { get; }

    public PartialUpdateClientDatabaseNumberCommandHandler(
        ClientApiDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<ClientDatabaseNumber> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<ClientDatabaseNumberKeyDto?> Handle(PartialUpdateClientDatabaseNumberCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<ClientDatabaseNumber,DatabaseNumber>("Id", request.keyId);
    
        var entity = await DbContext.ClientDatabaseNumbers.FindAsync(keyId);
        if (entity == null)
        {
            return null;
        }
        EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<ClientDatabaseNumber>(), request.UpdatedProperties, request.DeletedPropertyNames);

        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();
        return new ClientDatabaseNumberKeyDto(entity.Id.Value);
    }
}