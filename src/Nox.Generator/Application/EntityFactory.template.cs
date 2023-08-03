// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Domain;
using Nox.Application;
using {{codeGeneratorState.ODataNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};


namespace {{codeGeneratorState.ApplicationNameSpace}};

public class {{className}}: EntityFactoryBase<O{{entity.Name}}, {{entity.Name}}>
{
    public  {{className}}(NoxSolution noxSolution): base(noxSolution) { }

    protected override void MapEntity({{entity.Name}} entity, Entity entityDefinition, O{{entity.Name}} dto)
    {
        // TODO Map entity
    }
}