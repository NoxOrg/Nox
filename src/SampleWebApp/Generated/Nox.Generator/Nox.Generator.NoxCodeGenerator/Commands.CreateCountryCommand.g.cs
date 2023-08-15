// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Application;
using Nox.Factories;
using Nox.Solution.Extensions;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
//TODO support multiple keys and generated keys like nuid database number
public record CreateCountryCommand(CountryCreateDto EntityDto) : IRequest<System.String>;

public class CreateCountryCommandHandler: IRequestHandler<CreateCountryCommand, System.String>
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
    
    public async Task<System.String> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
        DbContext.Countries.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return default(System.String)!;
}
}