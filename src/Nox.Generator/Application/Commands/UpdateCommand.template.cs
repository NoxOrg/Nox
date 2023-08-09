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

public record Update{{entity.Name}}Command({{entity.KeysFlattenComponentsType[entity.Keys[0].Name]}} key, {{entity.Name}}Dto EntityDto) : IRequest<bool>;

public class Update{{entity.Name}}CommandHandler: CommandBase, IRequestHandler<Update{{entity.Name}}Command, bool>
{
    public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }    

    public  Update{{entity.Name}}CommandHandler(
        {{codeGeneratorState.Solution.Name}}DbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
    }
    
    public async Task<bool> Handle(Update{{entity.Name}}Command request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.{{entity.PluralName}}.FindAsync(CreateNoxTypeForKey<{{entity.Name}},{{entity.Keys[0].Type}}>("{{entity.Keys[0].Name}}", request.EntityDto));
        if (entity == null)
        {
            return false;
        }
        // Todo map dto
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return result > 0;        
    }
}