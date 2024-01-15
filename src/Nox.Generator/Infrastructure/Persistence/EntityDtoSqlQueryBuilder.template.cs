// Generated
{{- func isLocalizedText(attribute)
	ret attribute.IsLocalizedText
end -}}
{{- func isEnum(attribute)
	ret attribute.Type == "Enumeration"
end -}}
{{- func isLocalizedEnum(attribute)
	ret attribute.IsLocalizedEnum
end -}}
{{- func enumTableName(enumName) 
	ret entity.PluralName | string.append Pluralize(enumName)
end -}}
{{- func localizedEnumTableName(enumName) 
	ret enumTableName(enumName) | string.append "Localized"
end -}}
{{- hasLocalizedText = entityAttributes | array.each @isLocalizedText | array.contains true }}
{{- hasLocalizedEnum = entityAttributes | array.each @isLocalizedEnum | array.contains true }}
{{- entityTableName = entity.PluralName }}
{{- localizedEntityTableName = entity.PluralName | string.append "Localized" }}
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace {{codeGenConventions.RootNameSpace}}.Infrastructure.Persistence;

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
		var query = {{entity.Name}}Query();
		return CompileToSqlString(query);
	}
	
	private static Query {{entity.Name}}Query()
	{
		return new Query("{{entityTableName}}")
			{{- for key in entityKeys}}
			.Select("{{entityTableName}}.{{key.Name}}")
			{{- end}}
			{{- for attribute in entityAttributes}}
			{{- if !(isLocalizedText attribute)}}
			.Select("{{entityTableName}}.{{attribute.Name}}")
			{{- end}}
			{{- end}}
			{{- for attribute in entityAttributes}}
			{{- if isLocalizedText attribute}}
			.ForSqlServer(q => q.SelectRaw("COALESCE([{{localizedEntityTableName}}].[{{attribute.Name}}], (N'[' + COALESCE([{{entityTableName}}].[{{attribute.Name}}], N'')) + N']') AS [{{attribute.Name}}]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"{{localizedEntityTableName}}\".\"{{attribute.Name}}\", ('##OPEN##' || COALESCE(\"{{entityTableName}}\".\"{{attribute.Name}}\", '')) || '##CLOSE##') AS \"{{attribute.Name}}\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"{{localizedEntityTableName}}\".\"{{attribute.Name}}\", ('##OPEN##' || COALESCE(\"{{entityTableName}}\".\"{{attribute.Name}}\", '')) || '##CLOSE##') AS \"{{attribute.Name}}\""))
			{{- else if isEnum attribute}}
			.Select("{{enumTableName attribute.Name}}.Name as {{attribute.Name}}Name")
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
			{{- if entity.Persistence?.IsAudited == true }}
			.Select("{{entity.PluralName}}.DeletedAtUtc")
			{{- end }}
			.Select("{{entityTableName}}.Etag")
			{{- end }}
			{{- if hasLocalizedText}}
			.LeftJoin({{entity.Name}}LocalizedQuery(), j => j.On("{{localizedEntityTableName}}.{{entityKeys[0].Name}}", "{{entityTableName}}.{{entityKeys[0].Name}}"))
			{{- end}}
			{{- for attribute in entityAttributes | array.filter @isEnum}}
			.LeftJoin({{attribute.Name}}EnumQuery(), j => j.On("{{enumTableName attribute.Name}}.Id", "{{entityTableName}}.{{attribute.Name}}"))
			{{- end -}};
	}
	{{- if hasLocalizedText}}
	
	private static Query {{entity.Name}}LocalizedQuery()
	{
		return new Query("{{localizedEntityTableName}}")
			{{- for key in entityKeys}}
			.Select("{{localizedEntityTableName}}.{{key.Name}}")
			{{- end}}
			{{- for attribute in entityAttributes | array.filter @isLocalizedText}}
			.Select("{{localizedEntityTableName}}.{{attribute.Name}}")
			{{- end}}
			.Where("{{localizedEntityTableName}}.CultureCode", "##LANG##")
			.As("{{localizedEntityTableName}}");
	}
	{{- end}}
	{{- for attribute in entityAttributes | array.filter @isEnum }}
	
	private static Query {{attribute.Name}}EnumQuery()
	{
		return new Query("{{enumTableName attribute.Name}}")
			.Select("{{enumTableName attribute.Name}}.Id")
		{{- if isLocalizedEnum attribute }}
			.ForSqlServer(q => q.SelectRaw("COALESCE([{{localizedEnumTableName attribute.Name}}].[Name], (N'[' + COALESCE([{{enumTableName attribute.Name}}].[Name], N'')) + N']') AS [Name]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"{{localizedEnumTableName attribute.Name}}\".\"Name\", ('##OPEN##' || COALESCE(\"{{enumTableName attribute.Name}}\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"{{localizedEnumTableName attribute.Name}}\".\"Name\", ('##OPEN##' || COALESCE(\"{{enumTableName attribute.Name}}\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.LeftJoin({{attribute.Name}}LocalizedEnumQuery(), j => j.On("{{localizedEnumTableName attribute.Name}}.Id", "{{enumTableName attribute.Name}}.Id"))
		{{- else }}
			.Select("{{enumTableName attribute.Name}}.Name")
		{{- end }}
			.As("{{enumTableName attribute.Name}}");
	}
	{{- if isLocalizedEnum attribute }}
	
	private static Query {{attribute.Name}}LocalizedEnumQuery()
	{ 
		return new Query("{{localizedEnumTableName attribute.Name}}")
			.Select("{{localizedEnumTableName attribute.Name}}.Id")
			.Select("{{localizedEnumTableName attribute.Name}}.Name")
			.Where("{{localizedEnumTableName attribute.Name}}.CultureCode", "##LANG##")
			.As("{{localizedEnumTableName attribute.Name}}");
	}
	{{- end }}
	{{- end}}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			{{- if hasLocalizedText || hasLocalizedEnum }}
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]")
			{{- end -}};
	}
}