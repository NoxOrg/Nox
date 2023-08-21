// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Factories;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
//TODO support multiple keys and generated keys like nuid database number
public record CreateStoreSecurityPasswordsResponse(System.String keyId);

public record CreateStoreSecurityPasswordsCommand(StoreSecurityPasswordsCreateDto EntityDto) : IRequest<CreateStoreSecurityPasswordsResponse>;

public class CreateStoreSecurityPasswordsCommandHandler: IRequestHandler<CreateStoreSecurityPasswordsCommand, CreateStoreSecurityPasswordsResponse>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<StoreSecurityPasswordsCreateDto,StoreSecurityPasswords> EntityFactory { get; }

    public  CreateStoreSecurityPasswordsCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<StoreSecurityPasswordsCreateDto,StoreSecurityPasswords> entityFactory,
        IUserProvider userProvider,
        ISystemProvider systemProvider)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<CreateStoreSecurityPasswordsResponse> Handle(CreateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = CreateEntity(request);
	
        DbContext.StoreSecurityPasswords.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return new CreateStoreSecurityPasswordsResponse(default(System.String)!);
    }

    private StoreSecurityPasswords CreateEntity(CreateStoreSecurityPasswordsCommand request)
    {
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
        
        var createdBy = _userProvider.GetUser();
        var createdVia = _systemProvider.GetSystem();
        entityToCreate.Created(createdBy, createdVia);

        return entityToCreate;
    }
}