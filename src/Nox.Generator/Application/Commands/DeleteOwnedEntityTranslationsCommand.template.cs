{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = (prefix + name)	
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}
// Generated

#nullable enable
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;
using Nox.Extensions;

using {{codeGenConventions.DomainNameSpace}};
using {{entity.Name}}LocalizedEntity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}}Localized;

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

public partial record  {{className}}({{parentPrimaryKeys}}, {{if relationship.WithMultiEntity}}{{ownedPrimaryKeys}}, {{end}}Nox.Types.CultureCode {{codeGenConventions.LocalizationCultureField}}) : IRequest<bool>;

internal partial class {{ className}}Handler : {{ className}}HandlerBase
{
    public {{className}}Handler(
        IRepository repository,
        NoxSolution noxSolution)
        : base(repository, noxSolution)
    {
    }
}

internal abstract class {{ className}}HandlerBase : CommandBase<{{className}}, {{entity.Name}}LocalizedEntity>, IRequestHandler<{{className}}, bool>
{
    public IRepository Repository { get; }

    public {{className}}HandlerBase(
        IRepository repository,
        NoxSolution noxSolution) 
        : base(noxSolution)
    {
        Repository = repository;
    }

    public virtual async Task<bool> Handle({{ className}} command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
        
        var keys = new List<object?>({{parent.Keys | array.size}});
		{{- for key in parent.Keys }}
		keys.Add(Dto.{{parent.Name}}Metadata.Create{{key.Name}}(command.key{{key.Name}}));
		{{- end }}

        var parentEntity = await Repository.FindAsync<{{codeGenConventions.DomainNameSpace}}.{{parent.Name}}>(keys.ToArray(), cancellationToken);
        EntityNotFoundException.ThrowIfNull(parentEntity, "{{parent.Name}}", "{{keysToString parent.Keys 'parentKey' }}");

        {{ if relationship.WithSingleEntity -}}
        var entity = await Repository.Query<{{codeGenConventions.DomainNameSpace}}.{{entity.Name}}Localized>().SingleOrDefaultAsync(x => {{for key in parent.Keys}}x.{{parent.Name}}{{key.Name}} == parentEntity.{{key.Name}} && {{end}}x.CultureCode == command.CultureCode, cancellationToken);
        EntityLocalizationNotFoundException.ThrowIfNull(entity, "{{parent.Name}}.{{GetNavigationPropertyName parent relationship}}", String.Empty, command.{{codeGenConventions.LocalizationCultureField}}.ToString());        
        {{- else -}}       
        var entity = await Repository.Query<{{codeGenConventions.DomainNameSpace}}.{{entity.Name}}Localized>().SingleOrDefaultAsync(x => {{for key in entity.Keys}}x.{{key.Name}} == Dto.{{entity.Name}}Metadata.Create{{key.Name}}(command.relatedKey{{key.Name}}) && {{end}}x.CultureCode == command.CultureCode, cancellationToken);
        EntityLocalizationNotFoundException.ThrowIfNull(entity, "{{parent.Name}}.{{GetNavigationPropertyName parent relationship}}", "{{keysToString entity.Keys 'entityKey' }}", command.{{codeGenConventions.LocalizationCultureField}}.ToString());        
        {{- end }}
        
        Repository.Delete(entity);
        await OnCompletedAsync(command, entity);
        await Repository.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}

public class {{className}}Validator : AbstractValidator<{{className}}>
{
    public {{className}}Validator(NoxSolution noxSolution)
    {
        var defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);

		RuleFor(x => x.{{codeGenConventions.LocalizationCultureField}})
			.Must(x => x != defaultCultureCode)
			.WithMessage($"{%{{}%}nameof({{className}}){%{}}%} : {%{{}%}nameof({{className}}.{{codeGenConventions.LocalizationCultureField}}){%{}}%} cannot be the default culture code: {defaultCultureCode.Value}.");
			
    }
}