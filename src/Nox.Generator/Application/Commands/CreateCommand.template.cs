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
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

{{- keyType = SinglePrimitiveTypeForKey entity.Keys[0] }}
//TODO support multiple keys and generated keys like nuid database number
public record Create{{entity.Name}}Command({{entity.Name}}CreateDto EntityDto) : IRequest<{{keyType}}>;

public class Create{{entity.Name}}CommandHandler: IRequestHandler<Create{{entity.Name}}Command, {{keyType}}>
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
    
    public async Task<{{keyType}}> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        //TODO for nuid property or key needs to call ensure id        
        DbContext.{{entity.PluralName}}.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.{{entity.Keys[0].Name}}.Value;
        return default({{keyType}})!;
}
}