// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Application;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
//TODO support multiple keys and generated keys like nuid database number
public record CreateStoreCommand(StoreCreateDto EntityDto) : IRequest<StoreKeyDto>;

public class CreateStoreCommandHandler: IRequestHandler<CreateStoreCommand, StoreKeyDto>
{
    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<StoreCreateDto,Store> EntityFactory { get; }

    public  CreateStoreCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<StoreCreateDto,Store> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<StoreKeyDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
        DbContext.Stores.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return new StoreKeyDto(entityToCreate.Id.Value);
}
}