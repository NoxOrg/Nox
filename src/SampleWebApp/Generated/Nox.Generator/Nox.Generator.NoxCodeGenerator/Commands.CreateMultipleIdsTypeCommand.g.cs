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

//TODO support multiple keys and generated keys like nuid database number
public record CreateMultipleIdsTypeCommand(MultipleIdsTypeCreateDto EntityDto) : IRequest<Text>;

public class CreateMultipleIdsTypeCommandHandler: IRequestHandler<CreateMultipleIdsTypeCommand, Text>
{
    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<MultipleIdsTypeCreateDto,MultipleIdsType> EntityFactory { get; }

    public  CreateMultipleIdsTypeCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<MultipleIdsTypeCreateDto,MultipleIdsType> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<Text> Handle(CreateMultipleIdsTypeCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        //TODO for nuid property or key needs to call ensure id        
        DbContext.MultipleIdsTypes.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return entityToCreate.Id1;
    }
}