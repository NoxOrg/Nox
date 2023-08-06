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
public record CreateCurrencyCommand(CurrencyCreateDto EntityDto) : IRequest<Nuid>;

public class CreateCurrencyCommandHandler: IRequestHandler<CreateCurrencyCommand, Nuid>
{
    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<CurrencyCreateDto,Currency> EntityFactory { get; }

    public  CreateCurrencyCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<CurrencyCreateDto,Currency> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<Nuid> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        //TODO for nuid property or key needs to call ensure id        
        DbContext.Currencies.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return entityToCreate.Id;
    }
}