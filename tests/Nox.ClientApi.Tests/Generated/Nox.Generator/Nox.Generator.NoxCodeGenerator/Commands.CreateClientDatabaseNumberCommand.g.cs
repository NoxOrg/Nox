// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Application;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;
public record CreateClientDatabaseNumberCommand(ClientDatabaseNumberCreateDto EntityDto) : IRequest<ClientDatabaseNumberKeyDto>;

public class CreateClientDatabaseNumberCommandHandler: IRequestHandler<CreateClientDatabaseNumberCommand, ClientDatabaseNumberKeyDto>
{
    public ClientApiDbContext DbContext { get; }
    public IEntityFactory<ClientDatabaseNumberCreateDto,ClientDatabaseNumber> EntityFactory { get; }

    public  CreateClientDatabaseNumberCommandHandler(
        ClientApiDbContext dbContext,
        IEntityFactory<ClientDatabaseNumberCreateDto,ClientDatabaseNumber> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }

    public async Task<ClientDatabaseNumberKeyDto> Handle(CreateClientDatabaseNumberCommand request, CancellationToken cancellationToken)
    {
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

        DbContext.ClientDatabaseNumbers.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return new ClientDatabaseNumberKeyDto(entityToCreate.Id.Value);
    }
}