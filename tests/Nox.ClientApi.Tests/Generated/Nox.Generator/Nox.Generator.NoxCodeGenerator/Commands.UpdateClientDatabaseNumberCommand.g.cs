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

public record UpdateClientDatabaseNumberCommand(System.Int64 keyId, ClientDatabaseNumberUpdateDto EntityDto) : IRequest<ClientDatabaseNumberKeyDto?>;

public class UpdateClientDatabaseNumberCommandHandler: CommandBase, IRequestHandler<UpdateClientDatabaseNumberCommand, ClientDatabaseNumberKeyDto?>
{
    public ClientApiDbContext DbContext { get; }
    public IEntityMapper<ClientDatabaseNumber> EntityMapper { get; }

    public  UpdateClientDatabaseNumberCommandHandler(
        ClientApiDbContext dbContext,
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<ClientDatabaseNumber> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
        EntityMapper = entityMapper;
    }

    public async Task<ClientDatabaseNumberKeyDto?> Handle(UpdateClientDatabaseNumberCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<ClientDatabaseNumber,DatabaseNumber>("Id", request.keyId);

        var entity = await DbContext.ClientDatabaseNumbers.FindAsync(keyId);
        if (entity == null)
        {
            return null;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<ClientDatabaseNumber>(), request.EntityDto);

        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();
        if(result < 1)
            return null;

        return new ClientDatabaseNumberKeyDto(entity.Id.Value);
    }
}