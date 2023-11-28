// Generated

#nullable enable

using MediatR;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Exceptions;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

{{- for enumAtt in enumerationAttributes }}

{{-upsertCommand = 'Upsert' +  (entity.PluralName) +  (Pluralize (enumAtt.Attribute.Name)) + 'TranslationsCommand' }}
{{-contextProperty = (entity.PluralName) +  (Pluralize (enumAtt.Attribute.Name)) }}
{{-enumEntity = enumAtt.EntityNameForLocalizedEnumeration }}
public partial record  {{upsertCommand}}(IEnumerable<{{enumAtt.EntityDtoNameForLocalizedEnumeration}}> {{enumAtt.EntityDtoNameForLocalizedEnumeration}}s) : IRequest<IEnumerable<{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>>;

internal partial class {{upsertCommand}}Handler : {{upsertCommand}}HandlerBase
{
	public {{upsertCommand}}Handler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class {{upsertCommand}}HandlerBase : CommandBase<{{upsertCommand}}, {{enumEntity}}>, IRequestHandler<{{upsertCommand}}, IEnumerable<{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>>
{
	public AppDbContext DbContext { get; }
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("{{codeGeneratorState.Solution.Application.Localization.DefaultCulture}}");

	public {{upsertCommand}}HandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<IEnumerable<{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>> Handle({{upsertCommand}} command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);

		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var cultureCodes = command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.DistinctBy(d=>d.CultureCode).Select(d=>CultureCode.From(d.CultureCode)).ToList();
		
		var localizedEntities = await DbContext.{{contextProperty}}Localized.Where(x => cultureCodes.Contains(x.CultureCode)).AsNoTracking().ToListAsync(cancellationToken);
		
		var entities = new List<{{enumEntity}}>();
		
		command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.Where(dto=> !localizedEntities.Any(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode))).ForEach(dto =>
		{
			var e = new {{enumEntity}} {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
			DbContext.Entry(e).State = EntityState.Added;
			entities.Add(e);
		});
		
		command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.Where(dto=> localizedEntities.Any(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode))).ForEach(dto =>
		{
			var e = new {{enumEntity}} {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
			DbContext.Entry(e).State = EntityState.Modified;
			entities.Add(e);
		});
		
		command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.Where(dto=>dto.CultureCode == _defaultCultureCode.Value).ForEach(dto =>
		{
			var e = new {{enumAtt.EntityNameForEnumeration}} { Id = Enumeration.FromDatabase(dto.Id), Name = dto.Name };
			DbContext.Entry(e).State = EntityState.Modified;
		});
		

		await OnBatchCompletedAsync(command, localizedEntities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s;
	}
}
public class {{upsertCommand}}Validator : AbstractValidator<{{upsertCommand}}>
{
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("{{codeGeneratorState.Solution.Application.Localization.DefaultCulture}}");
	private static readonly string[] _supportedCultureCodes = new string[]
	{
		{{- for cultureCode in codeGeneratorState.Solution.Application.Localization.SupportedCultures }}
		"{{cultureCode}}",
		{{- end}}
	};
    public {{upsertCommand}}Validator(NoxSolution noxSolution)
    {
		RuleFor(x => x.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s)
			.Must(x => x != null && x.Count() > 0)
			.WithMessage($"{%{{}%}nameof({{upsertCommand}}){%{}}%} : {%{{}%}nameof({{upsertCommand}}.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s){%{}}%} is required.");
		
		RuleForEach(x => x.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s)
			.Must(x => _supportedCultureCodes.Contains(x.CultureCode))
			.WithMessage((_,x) => $"{%{{}%}nameof({{upsertCommand}}){%{}}%} : {%{{}%}nameof({{upsertCommand}}.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s){%{}}%} contains unsupported culture code: {x.CultureCode}.");
    }
}
{{- end}}