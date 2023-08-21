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
public record CreateCountryResponse(System.Int64 keyId);

public record CreateCountryCommand(CountryCreateDto EntityDto) : IRequest<CreateCountryResponse>;

public class CreateCountryCommandHandler: IRequestHandler<CreateCountryCommand, CreateCountryResponse>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<CountryCreateDto,Country> EntityFactory { get; }

    public  CreateCountryCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<CountryCreateDto,Country> entityFactory,
        IUserProvider userProvider,
        ISystemProvider systemProvider)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<CreateCountryResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = CreateEntity(request);
	
        DbContext.Countries.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return new CreateCountryResponse(default(System.Int64)!);
    }

    private Country CreateEntity(CreateCountryCommand request)
    {
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
        
        var createdBy = _userProvider.GetUser();
        var createdVia = _systemProvider.GetSystem();
        entityToCreate.Created(createdBy, createdVia);

        return entityToCreate;
    }
}