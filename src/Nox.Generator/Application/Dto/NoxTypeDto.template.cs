// Generated

#nullable enable
using Nox.Types;
using Microsoft.EntityFrameworkCore;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

{{~ for noxType in compoundTypes ~}}
[Owned]
public record {{noxType.NoxType}}Dto(
    {{- noxType.Components | array.join "," -}}
    );

{{~ end ~}}