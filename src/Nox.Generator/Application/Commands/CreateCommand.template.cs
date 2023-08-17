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
public record Create{{entity.Name}}Response({{primaryKeys}});

public record Create{{entity.Name}}Command({{entity.Name}}CreateDto EntityDto) : IRequest<Create{{entity.Name}}Response>;

public class Create{{entity.Name}}CommandHandler: IRequestHandler<Create{{entity.Name}}Command, Create{{entity.Name}}Response>
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
    
    public async Task<Create{{entity.Name}}Response> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        
		{{- for key in entity.Keys ~}}
		{{- if key.Type == "Nuid" }} 
		entityToCreate.Ensure{{key.Name}}();
		{{- end }}
		{{- end }}

        {{- if (entity.Persistence?.IsAudited ?? true)}}
        entityToCreate.Created();
        {{- end}}
	
        DbContext.{{entity.PluralName}}.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.{{entity.Keys[0].Name}}.Value;
        return new Create{{entity.Name}}Response({{primaryKeysQuery}});
}
}