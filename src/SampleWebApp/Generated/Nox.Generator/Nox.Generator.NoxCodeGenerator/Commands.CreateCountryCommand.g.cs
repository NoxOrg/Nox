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
public record CreateCountryCommand(CountryCreateDto EntityDto) : IRequest<CountryKeyDto>;

public class CreateCountryCommandHandler: IRequestHandler<CreateCountryCommand, CountryKeyDto>
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
    
    public async Task<CountryKeyDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
        DbContext.Countries.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return new CountryKeyDto(entityToCreate.Id.Value);
}
}