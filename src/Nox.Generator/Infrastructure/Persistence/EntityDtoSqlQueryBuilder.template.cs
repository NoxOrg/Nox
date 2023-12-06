// Generated
{{- func isLocalizedText(attribute)
	ret attribute.TextTypeOptions?.IsLocalized
end -}}
{{- func isEnum(attribute)
	ret attribute.Type == "Enumeration"
end -}}
{{- func isLocalizedEnum(attribute)
	ret attribute.EnumerationTypeOptions?.IsLocalized
end -}}
{{- func enumTableName(enumName) 
	ret entity.PluralName | string.append Pluralize(enumName)
end -}}
{{- func localizedEnumTableName(enumName) 
	ret enumTableName(enumName) | string.append "Localized"
end -}}
{{- hasLocalizedText = entity.Attributes | array.each @isLocalizedText | array.contains true }}
{{- hasLocalizedEnum = entity.Attributes | array.each @isLocalizedEnum | array.contains true }}
{{- entityTableName = entity.PluralName }}
{{- localizedEntityTableName = entity.PluralName | string.append "Localized" }}
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace {{codeGeneratorState.RootNameSpace}}.Infrastructure.Persistence;

public class {{className}} : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public {{className}}(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "{{entity.Name}}";

	public string Build()
	{
		{{- if hasLocalizedText}}
		var localizedEntityQuery = new Query("{{localizedEntityTableName}}")
			{{- for key in entityKeys}}
			.Select("{{localizedEntityTableName}}.{{key.Name}}")
			{{- end}}
			{{- for attribute in entity.Attributes | array.filter @isLocalizedText}}
			.Select("{{localizedEntityTableName}}.{{attribute.Name}}")
			{{- end}}
			.Where("{{localizedEntityTableName}}.CultureCode", "##LANG##")
			.As("{{localizedEntityTableName}}");
		{{ else if hasLocalizedEnum }}
		{{- for attribute in entity.Attributes | array.filter @isEnum }}
		var localized{{attribute.Name}}EnumQuery = new Query("{{localizedEnumTableName attribute.Name}}")
			.Select("{{localizedEnumTableName attribute.Name}}.Id")
			.Select("{{localizedEnumTableName attribute.Name}}.Name")
			.Where("{{localizedEnumTableName attribute.Name}}.CultureCode", "##LANG##")
			.As("{{localizedEnumTableName attribute.Name}}");

		var {{attribute.Name | string.downcase}}EnumQuery = new Query("{{enumTableName attribute.Name}}")
			.Select("{{enumTableName attribute.Name}}.Id")
			.ForSqlServer(q => q.SelectRaw("COALESCE([{{localizedEnumTableName attribute.Name}}].[Name], (N'[' + COALESCE([{{enumTableName attribute.Name}}].[Name], N'')) + N']') AS [Name]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"{{localizedEnumTableName attribute.Name}}\".\"Name\", ('##OPEN##' || COALESCE(\"{{enumTableName attribute.Name}}\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"{{localizedEnumTableName attribute.Name}}\".\"Name\", ('##OPEN##' || COALESCE(\"{{enumTableName attribute.Name}}\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.LeftJoin(localized{{attribute.Name}}EnumQuery, j => j.On("{{localizedEnumTableName attribute.Name}}.Id", "{{enumTableName attribute.Name}}.Id"))
			.As("{{enumTableName attribute.Name}}");
		{{- end}}
		{{end}}
		var entityQuery = new Query("{{entityTableName}}")
			{{- for key in entityKeys}}
			.Select("{{entityTableName}}.{{key.Name}}")
			{{- end}}
			{{- for attribute in entity.Attributes}}
			{{- if !(isLocalizedText attribute)}}
			.Select("{{entityTableName}}.{{attribute.Name}}")
			{{- end}}
			{{- end}}
			{{- for attribute in entity.Attributes}}
			{{- if isLocalizedText attribute}}
			.ForSqlServer(q => q.SelectRaw("COALESCE([{{localizedEntityTableName}}].[{{attribute.Name}}], (N'[' + COALESCE([{{entityTableName}}].[{{attribute.Name}}], N'')) + N']') AS [{{attribute.Name}}]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"{{localizedEntityTableName}}\".\"{{attribute.Name}}\", ('##OPEN##' || COALESCE(\"{{entityTableName}}\".\"{{attribute.Name}}\", '')) || '##CLOSE##') AS \"{{attribute.Name}}\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"{{localizedEntityTableName}}\".\"{{attribute.Name}}\", ('##OPEN##' || COALESCE(\"{{entityTableName}}\".\"{{attribute.Name}}\", '')) || '##CLOSE##') AS \"{{attribute.Name}}\""))
			{{- else if isLocalizedEnum attribute}}
			.Select("{{entityTableName}}.{{attribute.Name}}Name")
			{{- end}}
			{{- end}}
			{{- for relationship in entity.Relationships }}
			{{- if  relationship.IsForeignKeyOnThisSide && relationship.WithSingleEntity }}
			{{- relationshipName = GetNavigationPropertyName entity relationship}}
			.Select("{{entityTableName}}.{{relationshipName}}Id")
			{{-end}}
			{{- end }}
			{{- if entity.IsOwnedEntity && (entity.Keys | array.size > 0)}}
			.Select("{{entityTableName}}.{{entity.OwnerEntity.Name}}Id")
			{{- end }}
			{{- if !entity.IsOwnedEntity }}
			.Select("{{entityTableName}}.Etag")
			{{- end }}
			{{- if hasLocalizedText}}
			.LeftJoin(localizedEntityQuery, j => j.On("{{localizedEntityTableName}}.{{entityKeys[0].Name}}", "{{entityTableName}}.{{entityKeys[0].Name}}"))
			{{- else if hasLocalizedEnum }}
			{{- for attribute in entity.Attributes | array.filter @isLocalizedEnum}}
			.LeftJoin({{attribute.Name | string.downcase}}EnumQuery, j => j.On("{{enumTableName attribute.Name}}.Id", "{{entityTableName}}.{{attribute.Name}}"))
			{{- end}}
			{{- end -}};

		return _sqlCompiler.Compile(entityQuery).ToString().Replace("##OPEN##", "[").Replace("##CLOSE##", "]");
	}
}