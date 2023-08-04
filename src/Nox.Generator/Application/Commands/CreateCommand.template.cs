// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Application;
using Nox.Factories;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ODataNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;


namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

//TODO support multiple keys and generated keys like nuid database number
public record Create{{entity.Name}}Command({{entity.Name}}CreateDto EntityDto) : IRequest<{{entity.Keys[0].Type}}>;

public class Create{{entity.Name}}CommandHandler: IRequestHandler<Create{{entity.Name}}Command, {{entity.Keys[0].Type}}>
{
    public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }
    public IEntityFactory<{{entity.Name}}CreateDto,{{entity.Name}}> EntityFactory { get; }

    public  Create{{entity.Name}}CommandHandler(
        {{codeGeneratorState.Solution.Name}}DbContext dbContext,
        IEntityFactory<{{entity.Name}}CreateDto,{{entity.Name}}> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<{{entity.Keys[0].Type}}> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        //TODO support multiple keys and generated keys like nuid database number, and other type
        entityToCreate.{{entity.Keys[0].Name}} = Text.From(Guid.NewGuid().ToString().Substring(0, 2));
        DbContext.{{entity.PluralName}}.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return entityToCreate.{{entity.Keys[0].Name}};
    }
}