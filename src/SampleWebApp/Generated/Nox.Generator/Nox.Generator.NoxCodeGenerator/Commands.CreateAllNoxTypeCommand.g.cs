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
public record CreateAllNoxTypeCommand(AllNoxTypeCreateDto EntityDto) : IRequest<DatabaseNumber>;

public class CreateAllNoxTypeCommandHandler: IRequestHandler<CreateAllNoxTypeCommand, DatabaseNumber>
{
    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<AllNoxTypeCreateDto,AllNoxType> EntityFactory { get; }

    public  CreateAllNoxTypeCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<AllNoxTypeCreateDto,AllNoxType> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<DatabaseNumber> Handle(CreateAllNoxTypeCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        //TODO for nuid property or key needs to call ensure id        
        DbContext.AllNoxTypes.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return entityToCreate.Id;
    }
}