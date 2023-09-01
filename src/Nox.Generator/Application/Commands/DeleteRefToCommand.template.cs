﻿﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;
public record DeleteRef{{entity.Name}}To{{relatedEntity.Name}}Command({{entity.Name}}KeyDto EntityKeyDto
{{- if !isSingleRelationship }}, {{relatedEntity.Name}}KeyDto RelatedEntityKeyDto{{ end }}) : IRequest <bool>;

public partial class DeleteRef{{entity.Name}}To{{relatedEntity.Name}}CommandHandler: CommandBase<DeleteRef{{entity.Name}}To{{relatedEntity.Name}}Command, {{entity.Name}}>, 
	IRequestHandler <DeleteRef{{entity.Name}}To{{relatedEntity.Name}}Command, bool>
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }

	public DeleteRef{{entity.Name}}To{{relatedEntity.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteRef{{entity.Name}}To{{relatedEntity.Name}}Command request, CancellationToken cancellationToken)
	{
		OnExecuting(request);

		{{- for key in entity.Keys }}
		var key{{key.Name}} = CreateNoxTypeForKey<{{entity.Name}},{{SingleTypeForKey key}}>("{{key.Name}}", request.EntityKeyDto.key{{key.Name}});
		{{- end }}

		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{entityKeysFindQuery}});
		if (entity == null)
		{
			return false;
		}		

		{{- if isSingleRelationship }}
		entity.{{relatedEntity.Name}} = null;
		{{ else }}
		{{- for key in relatedEntity.Keys }}
		var relatedKey{{key.Name}} = CreateNoxTypeForKey<{{relatedEntity.Name}},{{SingleTypeForKey key}}>("{{key.Name}}", request.RelatedEntityKeyDto.key{{key.Name}});
		{{- end }}
		var relatedEntity = await DbContext.{{relatedEntity.PluralName}}.FindAsync({{relatedEntityKeysFindQuery}});
		if (relatedEntity == null)
		{
			return false;
		}
		entity.{{relatedEntity.PluralName}}.Remove(relatedEntity);
		{{- end }}

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}