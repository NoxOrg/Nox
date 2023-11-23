// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

{{- for enumAtt in enumerationAttributes }}

{{-deleteCommand = 'Delete' +  (entity.PluralName) +  (Pluralize (enumAtt.Attribute.Name)) + 'TranslationsCommand' }}
{{-enumEntity = enumAtt.EntityNameForLocalizedEnumeration }}
public partial record  {{deleteCommand}}(Nox.Types.CultureCode {{codeGeneratorState.LocalizationCultureField}}) : IRequest<bool>;

internal class {{deleteCommand}}Handler : {{deleteCommand}}HandlerBase
{
	public {{deleteCommand}}Handler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class {{deleteCommand}}HandlerBase : CommandBase<{{deleteCommand}}, {{enumEntity}}>, IRequestHandler<{{deleteCommand}}, bool>
{
	public AppDbContext DbContext { get; }

	public {{deleteCommand}}HandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle({{deleteCommand}} command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);

		// {{- for key in entity.Keys }}
		// {{- keyType = SingleTypeForKey key }}
		// var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(request.key{{key.Name}});
		// {{- end }}
		//
		// var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysQuery}});
		// if (entity == null{{if (entity.Persistence?.IsAudited ?? true)}} || entity.IsDeleted == true{{end}})
		// {
		// 	return false;
		// }
		// {{- if !entity.IsOwnedEntity }}
		//
		// entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		// {{- end }}
		//
		// await OnCompletedAsync(request, entity);
		//
		// {{- if (entity.Persistence?.IsAudited ?? true) }}
		// DbContext.Entry(entity).State = EntityState.Deleted;
		// {{-else-}}
		// DbContext.{{entity.PluralName}}.Remove(entity);
		// {{- end}}
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}

{{- end}}