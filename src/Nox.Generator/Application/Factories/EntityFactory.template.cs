// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.DomainNameSpace}};
using {{entity.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Factories;

public partial class {{className}} : EntityFactoryBase<{{entity.Name}}CreateDto,{{entity.Name}}>
{
    
}