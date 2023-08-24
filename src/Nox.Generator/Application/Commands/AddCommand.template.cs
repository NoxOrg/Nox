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
public record Add{{entity.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}CreateDto EntityDto) : IRequest <{{entity.Name}}KeyDto?>;

public partial class Add{{entity.Name}}CommandHandler: CommandBase<Add{{entity.Name}}Command, {{entity.Name}}>, IRequestHandler <Add{{entity.Name}}Command, {{entity.Name}}KeyDto?>
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }
	public IEntityFactory<{{entity.Name}}CreateDto,{{entity.Name}}> EntityFactory { get; }

	public Add{{entity.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<{{entity.Name}}CreateDto,{{entity.Name}}> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<{{entity.Name}}KeyDto?> Handle(Add{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		OnExecuting(request);

		{{- for key in parent.Keys }}
		var key{{key.Name}} = CreateNoxTypeForKey<{{parent.Name}},{{SingleTypeForKey key}}>("{{key.Name}}", request.ParentKeyDto.{{key.Name}});
		{{- end }}

		var parentEntity = await DbContext.{{parent.PluralName}}.FindAsync({{parentKeysFindQuery}});
		if (parentEntity == null)
		{
			return null;
		}

		var entity = EntityFactory.CreateEntity(request.EntityDto);

		{{- for key in entity.Keys ~}}
		{{- if key.Type == "Nuid" }}
		entityToCreate.Ensure{{key.Name}}();
		{{- end }}
		{{- end }}

		parentEntity.{{entity.PluralName}}.Add(entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new {{entity.Name}}KeyDto{ {{primaryKeysReturnQuery}} };
	}
}