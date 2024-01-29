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

{{-upsertCommand = 'Upsert' +  (entity.PluralName) +  (Pluralize (enumAtt.Attribute.Name)) + 'TranslationsCommand' }}
{{-enumEntity = enumAtt.EntityNameForLocalizedEnumeration }}
public partial record  {{upsertCommand}}(IEnumerable<{{enumAtt.EntityDtoNameForLocalizedEnumeration}}> {{enumAtt.EntityDtoNameForLocalizedEnumeration}}s) : IRequest<IEnumerable<{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>>;

internal partial class {{upsertCommand}}Handler : {{upsertCommand}}HandlerBase
{
	public {{upsertCommand}}Handler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class {{upsertCommand}}HandlerBase : CommandCollectionBase<{{upsertCommand}}, {{enumEntity}}>, IRequestHandler<{{upsertCommand}}, IEnumerable<{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>>
{
	public IRepository Repository { get; }
	public {{upsertCommand}}HandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<IEnumerable<{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>> Handle({{upsertCommand}} command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var cultureCodes = command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.DistinctBy(d=>d.CultureCode).Select(d=>CultureCode.From(d.CultureCode)).ToList();
		var localizedEntities = await Repository.Query<{{entity.Name}}{{enumAtt.Attribute.Name}}Localized>()
			.Where(x => cultureCodes.Contains(x.CultureCode))			
			.ToListAsync(cancellationToken);
		
		var entities = new List<{{enumEntity}}>();
		foreach(var dto in command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s)
		{
            var entity = localizedEntities.SingleOrDefault(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode));
	        if(entity is not null)
			{
                entity.Name = dto.Name;
                entities.Add(entity);
            }
			else
			{
				var e = new {{enumEntity}} {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
				await Repository.AddAsync(e, cancellationToken);
				entities.Add(e);
			}
        }
		
		//Update Default in Entity 
		command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.Where(dto=>dto.CultureCode == DefaultCultureCode.Value).ForEach(dto =>
		{
			var e = new {{enumAtt.EntityNameForEnumeration}} { Id = Enumeration.FromDatabase(dto.Id), Name = dto.Name };			
			Repository.Update(e);
		});
		

		await OnCompletedAsync(command, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s;
	}
}
public class {{upsertCommand}}Validator : AbstractValidator<{{upsertCommand}}>
{
	private static readonly int[] _supportedIds = new int[] { {{- for value in enumAtt.Attribute.EnumerationTypeOptions.Values }} {{value.Id}},{{- end}} };
	
    public {{upsertCommand}}Validator(NoxSolution noxSolution)
    {
		RuleFor(x => x.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s)
			.Must(x => x != null && x.Count() > 0)
			.WithMessage($"{%{{}%}nameof({{upsertCommand}}){%{}}%} : {%{{}%}nameof({{upsertCommand}}.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s){%{}}%} is required.");
		
		RuleForEach(x => x.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s)
			.Must(x => noxSolution!.Application!.Localization!.SupportedCultures.Select(c => c.ToDisplayName()).Contains(x.CultureCode))
			.WithMessage((_,x) => $"{%{{}%}nameof({{upsertCommand}}){%{}}%} : {%{{}%}nameof({{upsertCommand}}.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s){%{}}%} contains unsupported culture code: {x.CultureCode}.");
		
		RuleForEach(x => x.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s)
			.Must(x => _supportedIds.Contains(x.Id))
			.WithMessage((_,x) => $"{%{{}%}nameof({{upsertCommand}}){%{}}%} : {%{{}%}nameof({{upsertCommand}}.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s){%{}}%} contains unsupported Id: {x.Id}.");
    }
}
{{- end}}