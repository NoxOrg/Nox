// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Abstractions.Extensions;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

{{- for enumAtt in enumerationAttributes }}

{{-deleteCommand = 'Delete' +  (entity.PluralName) +  (Pluralize (enumAtt.Attribute.Name)) + 'TranslationsCommand' }}
{{-enumEntity = enumAtt.EntityNameForLocalizedEnumeration }}
public partial record  {{deleteCommand}}(Nox.Types.CultureCode {{codeGeneratorState.LocalizationCultureField}}) : IRequest<bool>;

internal partial class {{deleteCommand}}Handler : {{deleteCommand}}HandlerBase
{
	public {{deleteCommand}}Handler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class {{deleteCommand}}HandlerBase : CommandCollectionBase<{{deleteCommand}}, {{enumEntity}}>, IRequestHandler<{{deleteCommand}}, bool>
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

		var localizedEnums = await DbContext.{{entity.PluralName}}{{Pluralize (enumAtt.Attribute.Name)}}Localized.Where(x => x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
		
		if(!localizedEnums.Any())
		{
			return false;
		}
		
		await OnCompletedAsync(command, localizedEnums);
		
		DbContext.RemoveRange(localizedEnums);
		
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}

public class {{deleteCommand}}Validator : AbstractValidator<{{deleteCommand}}>
{
	public {{deleteCommand}}Validator(NoxSolution noxSolution)
    {
		RuleFor(x => x.{{codeGeneratorState.LocalizationCultureField}})
			.Must(x => x.Value != noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName())
			.WithMessage($"{%{{}%}nameof({{deleteCommand}}){%{}}%} : {%{{}%}nameof({{deleteCommand}}.{{codeGeneratorState.LocalizationCultureField}}){%{}}%} cannot be the default culture code: {noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName()}.");
			
    }
}	
{{- end}}