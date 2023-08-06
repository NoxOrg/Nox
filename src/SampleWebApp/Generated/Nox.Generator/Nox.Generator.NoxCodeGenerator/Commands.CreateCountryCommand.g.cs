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
using SampleWebApp.Presentation.Api.OData;
using SampleWebApp.Application.Dto;


namespace SampleWebApp.Application.Commands;

//TODO support multiple keys and generated keys like nuid database number
public record CreateCountryCommand(CountryCreateDto EntityDto) : IRequest<Text>;

public class CreateCountryCommandHandler: IRequestHandler<CreateCountryCommand, Text>
{
    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<CountryCreateDto,Country> EntityFactory { get; }

    public  CreateCountryCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<CountryCreateDto,Country> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<Text> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        //TODO for nuid property or key needs to call ensure id        
        DbContext.Countries.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return entityToCreate.Id;
    }
}