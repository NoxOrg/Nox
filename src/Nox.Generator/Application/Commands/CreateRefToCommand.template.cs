{{-relatedEntity = relationship.Related.Entity }}
// Generated

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
public record CreateRef{{entity.Name}}To{{relationship.Name}}Command({{entity.Name}}KeyDto EntityKeyDto, {{relatedEntity.Name}}KeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRef{{entity.Name}}To{{relationship.Name}}CommandHandler: CommandBase<CreateRef{{entity.Name}}To{{relationship.Name}}Command, {{entity.Name}}>, 
	IRequestHandler <CreateRef{{entity.Name}}To{{relationship.Name}}Command, bool>
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }

	public CreateRef{{entity.Name}}To{{relationship.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRef{{entity.Name}}To{{relationship.Name}}Command request, CancellationToken cancellationToken)
	{
		OnExecuting(request);

		{{- for key in entity.Keys }}
		var key{{key.Name}} = CreateNoxTypeForKey<{{entity.Name}}, Nox.Types.{{SingleTypeForKey key}}>("{{key.Name}}", request.EntityKeyDto.key{{key.Name}});
		{{- end }}
		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{entityKeysFindQuery}});
		if (entity == null)
		{
			return false;
		}


		{{- for key in relatedEntity.Keys }}
		var relatedKey{{key.Name}} = CreateNoxTypeForKey<{{relatedEntity.Name}}, Nox.Types.{{SingleTypeForKey key}}>("{{key.Name}}", request.RelatedEntityKeyDto.key{{key.Name}});
		{{- end }}
		var relatedEntity = await DbContext.{{relatedEntity.PluralName}}.FindAsync({{relatedEntityKeysFindQuery}});
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefTo{{relationship.Entity}}{{relationship.Name}}(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}