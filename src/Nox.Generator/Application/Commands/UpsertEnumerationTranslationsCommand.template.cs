// Generated

#nullable enable

using MediatR;
using System.Collections.Generic;
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
public partial record  {{upsertCommand}}(IEnumerable<{{enumAtt.EntityDtoNameForLocalizedEnumeration}}> {{enumAtt.EntityDtoNameForLocalizedEnumeration}}s) : IRequest<CultureCode>;

internal class {{upsertCommand}}Handler : {{upsertCommand}}HandlerBase
{
	public {{upsertCommand}}Handler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class {{upsertCommand}}HandlerBase : CommandBase<{{upsertCommand}}, {{enumEntity}}>, IRequestHandler<{{upsertCommand}}, CultureCode>
{
	public AppDbContext DbContext { get; }

	public {{upsertCommand}}HandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<CultureCode> Handle({{upsertCommand}} command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);

		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		if(command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s == null || command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.Count() == 0)
		{
			throw new ArgumentNullException($"No {nameof(command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s)} found.");
		}
		
		var cultureCode = command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.First().CultureCode;
		var supportedCultureCodes = NoxSolution.Application?.Localization?.SupportedCultures?.ToHashSet();
		var cultureCodeValue = Nox.Types.CultureCode.From(cultureCode);
		
		if (supportedCultureCodes == null || !supportedCultureCodes.Contains(cultureCode))
		{
			throw new CultureCodeNotSupportedException($"Culture code {cultureCode} not supported.");
		}
		
		if (!command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.All(x => x.CultureCode == cultureCode))
		{
			throw new CultureCodeMismatchException($"Culture code {cultureCode} does not match.");
		}
		
		var ids = command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.Select(dto=> Enumeration.From(dto.Id)).ToList();
		var query =
			from Enum in DbContext.{{contextProperty}}
			join localized in DbContext.{{contextProperty}}Localized
				on  new {Id = Enum.Id, Culture = cultureCodeValue}  equals new  {Id = localized.Id, Culture = localized.CultureCode} into localizedEnumsJoin
			from LocalizedEnum in localizedEnumsJoin.DefaultIfEmpty()
			select new { Enum.Id, LocalizedId = LocalizedEnum.Id };
		
		
		var queryResult = await query.AsNoTracking().ToListAsync(cancellationToken);
			
		if(!(queryResult.Count == ids.Count && queryResult.All(x=> ids.Contains(x.Id))))
		{
			throw new InvalidEnumIdsException($"Provided ids are invalid for {nameof(DbContext.{{contextProperty}})}.");
		}
		
		var localizedEntities = 
			command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.Select(dto => new {{enumAtt.EntityNameForLocalizedEnumeration}} {Id = Enumeration.From(dto.Id), CultureCode = cultureCodeValue, Name = dto.Name}).ToList();

		if (queryResult.First().LocalizedId == null)
		{
			DbContext.{{contextProperty}}Localized.AddRange(localizedEntities);
		}
		else
		{
			localizedEntities.ForEach(e=> DbContext.Entry(e).State = EntityState.Modified);
		}

		if (NoxSolution.Application?.Localization?.DefaultCulture == cultureCode)
		{
			command.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}s.ForEach(dto =>
			{
				var e = new {{enumAtt.EntityNameForEnumeration}} { Id = Enumeration.From(dto.Id), Name = dto.Name };
				DbContext.Entry(e).State = EntityState.Modified;
			});
		}

		await OnBatchCompletedAsync(command, localizedEntities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return cultureCodeValue;
	}
}

{{- end}}