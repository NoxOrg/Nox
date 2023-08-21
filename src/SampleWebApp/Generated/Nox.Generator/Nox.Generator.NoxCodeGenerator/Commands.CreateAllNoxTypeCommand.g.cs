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
public record CreateAllNoxTypeResponse(System.Int64 keyId, System.String keyTextId);

public record CreateAllNoxTypeCommand(AllNoxTypeCreateDto EntityDto) : IRequest<CreateAllNoxTypeResponse>;

public class CreateAllNoxTypeCommandHandler: IRequestHandler<CreateAllNoxTypeCommand, CreateAllNoxTypeResponse>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<AllNoxTypeCreateDto,AllNoxType> EntityFactory { get; }

    public  CreateAllNoxTypeCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<AllNoxTypeCreateDto,AllNoxType> entityFactory,
        IUserProvider userProvider,
        ISystemProvider systemProvider)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<CreateAllNoxTypeResponse> Handle(CreateAllNoxTypeCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = CreateEntity(request);
	
        DbContext.AllNoxTypes.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return new CreateAllNoxTypeResponse(default(System.Int64)!, default(System.String)!);
    }

    private AllNoxType CreateEntity(CreateAllNoxTypeCommand request)
    {
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
        
        var createdBy = _userProvider.GetUser();
        var createdVia = _systemProvider.GetSystem();
        entityToCreate.Created(createdBy, createdVia);

        return entityToCreate;
    }
}