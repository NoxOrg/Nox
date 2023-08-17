// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record PartialUpdate{{entity.Name}}Command({{primaryKeys}}, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<bool>;

public class PartialUpdate{{entity.Name}}CommandHandler: CommandBase, IRequestHandler<PartialUpdate{{entity.Name}}Command, bool>
{
    public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }    
    public IEntityMapper<{{entity.Name}}> EntityMapper { get; }

    public PartialUpdate{{entity.Name}}CommandHandler(
        {{codeGeneratorState.Solution.Name}}DbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<{{entity.Name}}> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(PartialUpdate{{entity.Name}}Command request, CancellationToken cancellationToken)
    {
    {{- for key in entity.Keys }}
        var key{{key.Name}} = CreateNoxTypeForKey<{{entity.Name}},{{SingleTypeForKey key}}>("{{key.Name}}", request.key{{key.Name}});
    {{- end }}
    
        var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysQuery}});
        if (entity == null)
        {
            return false;
        }
        EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<{{entity.Name}}>(), request.UpdatedProperties, request.DeletedPropertyNames);

        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();
        return result > 0;                
    }
}