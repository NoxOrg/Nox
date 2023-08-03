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


namespace SampleWebApp.Application.Commands;

//TODO support multiple keys and generated keys like nuid database number
public record CreateCountryLocalNamesCommand(CountryLocalNamesDto EntityDto) : IRequest<Text>;

public class CreateCountryLocalNamesCommandHandler: IRequestHandler<CreateCountryLocalNamesCommand, Text>
{
    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<CountryLocalNamesDto,CountryLocalNames> EntityFactory { get; }

    public  CreateCountryLocalNamesCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<CountryLocalNamesDto,CountryLocalNames> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<Text> Handle(CreateCountryLocalNamesCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        //TODO support multiple keys and generated keys like nuid database number, and other type
        entityToCreate.Id = Text.From(Guid.NewGuid().ToString().Substring(0, 2));
        DbContext.CountryLocalNames.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return entityToCreate.Id;
    }
}