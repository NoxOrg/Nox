﻿// Generated

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

{{- keyType = SingleTypeForKey entity.Keys[0] }}

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record Update{{entity.Name}}Command({{entity.KeysFlattenComponentsType[entity.Keys[0].Name]}} key, {{entity.Name}}UpdateDto EntityDto) : IRequest<bool>;

public class Update{{entity.Name}}CommandHandler: CommandBase, IRequestHandler<Update{{entity.Name}}Command, bool>
{
    public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }    
    public IEntityMapper<{{entity.Name}}> EntityMapper { get; }

    public  Update{{entity.Name}}CommandHandler(
        {{codeGeneratorState.Solution.Name}}DbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<{{entity.Name}}> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(Update{{entity.Name}}Command request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.{{entity.PluralName}}.FindAsync(CreateNoxTypeForKey<{{entity.Name}},{{keyType}}>("{{entity.Keys[0].Name}}", request.key));
        if (entity == null)
        {
            return false;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<{{entity.Name}}>(), request.EntityDto);
        // Todo map dto
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return result > 0;        
    }
}