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
public record CreateCountryLocalNamesResponse(System.String keyId);

public record CreateCountryLocalNamesCommand(CountryLocalNamesCreateDto EntityDto) : IRequest<CreateCountryLocalNamesResponse>;

public class CreateCountryLocalNamesCommandHandler: IRequestHandler<CreateCountryLocalNamesCommand, CreateCountryLocalNamesResponse>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<CountryLocalNamesCreateDto,CountryLocalNames> EntityFactory { get; }

    public  CreateCountryLocalNamesCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<CountryLocalNamesCreateDto,CountryLocalNames> entityFactory,
        IUserProvider userProvider,
        ISystemProvider systemProvider)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<CreateCountryLocalNamesResponse> Handle(CreateCountryLocalNamesCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = CreateEntity(request);
	
        DbContext.CountryLocalNames.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return new CreateCountryLocalNamesResponse(default(System.String)!);
    }

    private CountryLocalNames CreateEntity(CreateCountryLocalNamesCommand request)
    {
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
        
        var createdBy = _userProvider.GetUser();
        var createdVia = _systemProvider.GetSystem();
        entityToCreate.Created(createdBy, createdVia);

        return entityToCreate;
    }
}