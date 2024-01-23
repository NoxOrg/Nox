{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = ("{" + prefix + name + ".ToString()}")	
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}
// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using {{codeGenConventions.PersistenceNameSpace}};
using {{codeGenConventions.DomainNameSpace}};
using {{entity.Name}}LocalizedEntity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}}Localized;

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

public partial record  {{className}}({{primaryKeys}}, Nox.Types.CultureCode {{codeGenConventions.LocalizationCultureField}}) : IRequest<bool>;

internal partial class {{ className}}Handler : {{ className}}HandlerBase
{
    public {{ className}}Handler(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(dbContext, noxSolution)
    {
    }
}

internal abstract class {{ className}}HandlerBase : CommandBase<{{ className}}, {{entity.Name}}LocalizedEntity>, IRequestHandler<{{ className}}, bool>
{
    public AppDbContext DbContext { get; }

    public {{ className}}HandlerBase(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        DbContext = dbContext;
    }

    public virtual async Task<bool> Handle({{ className}} command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);

        {{- for key in entity.Keys }}
		var key{{key.Name}} = Dto.{{entity.Name}}Metadata.Create{{key.Name}}(command.key{{key.Name}});
		{{- end }}
        
        var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysFindQuery}});
        EntityNotFoundException.ThrowIfNull(entity, "{{entity.Name}}", $"{{entity.Keys | keysToString}}");
		
        var entityLocalized = await DbContext.{{entity.PluralName}}Localized.FirstOrDefaultAsync(x =>{{for key in entity.Keys}}x.{{key.Name}} == entity.{{key.Name}} && {{end}}x.CultureCode == command.CultureCode);
        EntityLocalizationNotFoundException.ThrowIfNull(entityLocalized, "{{entity.Name}}",  $"{{entity.Keys | keysToString}}", command.{{codeGenConventions.LocalizationCultureField}}.ToString());
        
        await OnCompletedAsync(command, entityLocalized);
        
        DbContext.Remove(entityLocalized);
        
        await DbContext.SaveChangesAsync(cancellationToken);
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