// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Domain;
using Nox.Exceptions;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Abstractions.Extensions;
using {{codeGenConventions.DomainNameSpace}};
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

{{- for enumAtt in enumerationAttributes }}

{{-deleteCommand = 'Delete' +  (entity.PluralName) +  (Pluralize (enumAtt.Attribute.Name)) + 'TranslationsCommand' }}
{{-enumEntity = enumAtt.EntityNameForLocalizedEnumeration }}
public partial record  {{deleteCommand}}(Enumeration Id, Nox.Types.CultureCode {{codeGenConventions.LocalizationCultureField}}) : IRequest<bool>;

internal partial class {{deleteCommand}}Handler : {{deleteCommand}}HandlerBase
{
	public {{deleteCommand}}Handler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class {{deleteCommand}}HandlerBase : CommandBase<{{deleteCommand}}, {{enumEntity}}>, IRequestHandler<{{deleteCommand}}, bool>
{
	public IRepository Repository { get; }

	public {{deleteCommand}}HandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle({{deleteCommand}} command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var enumEntity = await Repository.FindAsync<{{entity.Name}}{{enumAtt.Attribute.Name}}>(command.Id, cancellationToken);
        EntityNotFoundException.ThrowIfNull(enumEntity, "{{enumEntity}}", command.Id.Value.ToString());

		var localizedEnum = await Repository.Query<{{entity.Name}}{{enumAtt.Attribute.Name}}Localized>()
			.FirstOrDefaultAsync(x => x.Id == command.Id && x.CultureCode == command.CultureCode, cancellationToken);
		EntityLocalizationNotFoundException.ThrowIfNull(localizedEnum, "{{enumEntity}}",  command.Id.Value.ToString(), command.{{codeGenConventions.LocalizationCultureField}}.ToString());
		
		Repository.Delete(localizedEnum);

        await OnCompletedAsync(command, localizedEnum);
        await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}

public class {{deleteCommand}}Validator : AbstractValidator<{{deleteCommand}}>
{
	public {{deleteCommand}}Validator(NoxSolution noxSolution)
    {
		RuleFor(x => x.{{codeGenConventions.LocalizationCultureField}})
			.Must(x => x.Value != noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName())
			.WithMessage($"{%{{}%}nameof({{deleteCommand}}){%{}}%} : {%{{}%}nameof({{deleteCommand}}.{{codeGenConventions.LocalizationCultureField}}){%{}}%} cannot be the default culture code: {noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName()}.");
			
    }
}	
{{- end}}