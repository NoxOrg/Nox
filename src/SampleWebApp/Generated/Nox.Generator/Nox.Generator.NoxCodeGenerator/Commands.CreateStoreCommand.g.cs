// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Application;
using Nox.Factories;
using Nox.Abstractions;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
//TODO support multiple keys and generated keys like nuid database number
public record CreateStoreResponse(System.String keyId);

public record CreateStoreCommand(StoreCreateDto EntityDto) : IRequest<CreateStoreResponse>;

public class CreateStoreCommandHandler: IRequestHandler<CreateStoreCommand, CreateStoreResponse>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<StoreCreateDto,Store> EntityFactory { get; }

    public  CreateStoreCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<StoreCreateDto,Store> entityFactory,
        IUserProvider userProvider,
        ISystemProvider systemProvider)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<CreateStoreResponse> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = CreateEntity(request);
	
        DbContext.Stores.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return new CreateStoreResponse(default(System.String)!);
    }

    private Store CreateEntity(CreateStoreCommand request)
    {
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
        
        var createdBy = _userProvider.GetUser();
        var createdVia = _systemProvider.GetSystem();
        entityToCreate.Created(createdBy, createdVia);

        return entityToCreate;
    }
}