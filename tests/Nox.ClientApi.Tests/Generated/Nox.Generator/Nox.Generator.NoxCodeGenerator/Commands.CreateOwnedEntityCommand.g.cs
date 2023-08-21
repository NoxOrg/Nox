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
public record CreateOwnedEntityCommand(OwnedEntityCreateDto EntityDto) : IRequest<OwnedEntityKeyDto>;

public class CreateOwnedEntityCommandHandler: IRequestHandler<CreateOwnedEntityCommand, OwnedEntityKeyDto>
{
    public ClientApiDbContext DbContext { get; }
    public IEntityFactory<OwnedEntityCreateDto,OwnedEntity> EntityFactory { get; }

    public  CreateOwnedEntityCommandHandler(
        ClientApiDbContext dbContext,
        IEntityFactory<OwnedEntityCreateDto,OwnedEntity> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }

    public async Task<OwnedEntityKeyDto> Handle(CreateOwnedEntityCommand request, CancellationToken cancellationToken)
    {
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

        DbContext.OwnedEntities.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return new OwnedEntityKeyDto(entityToCreate.Id.Value);
    }
}