// Generated

#nullable enable

using MediatR;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Types.Abstractions.Extensions;
using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

{{- for enumAtt in enumerationAttributes }}

{{-upsertCommand = 'Upsert' +  (entity.PluralName) +  (Pluralize (enumAtt.Attribute.Name)) + 'TranslationCommand' }}
{{-enumEntity = enumAtt.EntityNameForLocalizedEnumeration }}
public partial record {{upsertCommand}}(Enumeration Id, {{enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}} {{enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}}, CultureCode CultureCode) : IRequest<{{enumAtt.EntityNameForLocalizedEnumeration}}KeyDto>;

internal partial class {{upsertCommand}}Handler : {{upsertCommand}}HandlerBase
{
	public {{upsertCommand}}Handler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class {{upsertCommand}}HandlerBase : CommandBase<{{upsertCommand}}, {{enumEntity}}>, IRequestHandler<{{upsertCommand}}, {{enumAtt.EntityNameForLocalizedEnumeration}}KeyDto>
{
	
	public IRepository Repository { get; }
	public {{upsertCommand}}HandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<{{enumAtt.EntityNameForLocalizedEnumeration}}KeyDto> Handle({{upsertCommand}} command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		
		var localizedEntity = await Repository.Query<{{entity.Name}}{{enumAtt.Attribute.Name}}Localized>()
			.Where(x =>x.Id == command.Id && x.CultureCode == command.CultureCode)			
			.FirstOrDefaultAsync(cancellationToken);
		
		if(localizedEntity is not null)
		{
			localizedEntity.Name = command.{{enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}}.Name;
		}
		else
		{
			localizedEntity = new {{enumEntity}} {Id = command.Id, CultureCode = command.CultureCode, Name = command.{{enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}}.Name};
			await Repository.AddAsync(localizedEntity, cancellationToken);
		}
		
		if(command.CultureCode == DefaultCultureCode)
		{
			var e = new {{enumAtt.EntityNameForEnumeration}} { Id = command.Id, Name = command.{{enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}}.Name };			
			Repository.Update(e);
		}
		
		

		await OnCompletedAsync(command, localizedEntity);
		await Repository.SaveChangesAsync(cancellationToken);
		return new {{enumAtt.EntityNameForLocalizedEnumeration}}KeyDto(command.Id.Value, command.CultureCode.Value);
	}
}
public class {{upsertCommand}}Validator : AbstractValidator<{{upsertCommand}}>
{
	private static readonly int[] _supportedIds = new int[] { {{- for value in enumAtt.Attribute.EnumerationTypeOptions.Values }} {{value.Id}},{{- end}} };
	
    public {{upsertCommand}}Validator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CultureCode)
			.Must(x => noxSolution!.Application!.Localization!.SupportedCultures.Select(c => c.ToDisplayName()).Contains(x.Value))
			.WithMessage((_,x) => $"{%{{}%}nameof({{upsertCommand}}){%{}}%} : {%{{}%}nameof({{upsertCommand}}.CultureCode){%{}}%}  not supported: {x.Value}.");
		
		RuleFor(x => x.Id)
			.Must(x => _supportedIds.Contains(x.Value))
			.WithMessage((_,x) => $"{%{{}%}nameof({{upsertCommand}}){%{}}%} : {%{{}%}nameof({{upsertCommand}}.Id){%{}}%} not supported: {x.Value}.");
    }
}
{{- end}}