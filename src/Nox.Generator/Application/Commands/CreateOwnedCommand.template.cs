﻿{{- relationshipName = GetNavigationPropertyName parent relationship }}﻿

{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = ("{" + prefix + name + ".ToString()}")
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using {{codeGenConventions.PersistenceNameSpace}};
using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;
public partial record Create{{relationshipName}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}UpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <{{entity.Name}}KeyDto>;

internal partial class Create{{relationshipName}}For{{parent.Name}}CommandHandler : Create{{relationshipName}}For{{parent.Name}}CommandHandlerBase
{
	public Create{{relationshipName}}For{{parent.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class Create{{relationshipName}}For{{parent.Name}}CommandHandlerBase : CommandBase<Create{{relationshipName}}For{{parent.Name}}Command, {{entity.Name}}Entity>, IRequestHandler<Create{{relationshipName}}For{{parent.Name}}Command, {{entity.Name}}KeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> _entityFactory;
	
	protected Create{{relationshipName}}For{{parent.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<{{entity.Name}}KeyDto?> Handle(Create{{relationshipName}}For{{parent.Name}}Command request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);

		{{- for key in parent.Keys }}
		var key{{key.Name}} = {{codeGenConventions.DomainNameSpace}}.{{parent.Name}}Metadata.Create{{key.Name}}(request.ParentKeyDto.key{{key.Name}});
		{{- end }}

		var parentEntity = await _dbContext.{{parent.PluralName}}.FindAsync({{parentKeysFindQuery}});
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("{{parent.Name}}",  $"{{parent.Keys | keysToString}}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefTo{{relationshipName}}(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
}

{{- if (entity.Keys | array.size) > 0 }}

public class Create{{relationshipName}}For{{parent.Name}}Validator : AbstractValidator<Create{{relationshipName}}For{{parent.Name}}Command>
{
    public Create{{relationshipName}}For{{parent.Name}}Validator()
    {
		{{- for key in entity.Keys }}
			{{- if key.Type == "Guid" }} {{ continue; }}
            {{- else if !IsNoxTypeCreatable key.Type }}
		RuleFor(x => x.EntityDto.{{key.Name}}).Null().WithMessage("{{key.Name}} must be null as it is auto generated.");
			{{- else }}
		RuleFor(x => x.EntityDto.{{key.Name}}).NotNull().WithMessage("{{key.Name}} is required.");
            {{- end }}
        {{- end }}
    }
}
{{- end }}