// Generated
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
		var localizedEntityQuery = new Query("{{entity.PluralName}}Localized")
			{{- for key in entityKeys}}
			.Select("{{entity.PluralName}}Localized.{{key.Name}}")
			{{- end}}
			{{- for attribute in entity.Attributes}}
			{{- if attribute.IsLocalized}}
			.Select("{{entity.PluralName}}Localized.{{attribute.Name}}")
			{{- end}}
			{{- end}}
			.Where("{{entity.PluralName}}Localized.CultureCode", "##LANG##")
			.As("{{entity.PluralName}}Localized");

		var entityQuery = new Query("{{entity.PluralName}}")
			{{- for key in entityKeys}}
			.Select("{{entity.PluralName}}.{{key.Name}}")
			{{- end}}
			{{- for attribute in entity.Attributes}}
			{{- if !attribute.IsLocalized }}
			.Select("{{entity.PluralName}}.{{attribute.Name}}")
			{{- end}}
			{{- end}}
			{{- for attribute in entity.Attributes}}
			{{- if attribute.IsLocalized}}
			.ForSqlServer(q => q.SelectRaw("COALESCE([{{entity.PluralName}}Localized].[{{attribute.Name}}], (N'[' + COALESCE([{{entity.PluralName}}].[{{attribute.Name}}], N'')) + N']') AS [{{attribute.Name}}]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"{{entity.PluralName}}Localized\".\"{{attribute.Name}}\", ('##OPEN##' || COALESCE(\"{{entity.PluralName}}\".\"{{attribute.Name}}\", '')) || '##CLOSE##') AS \"{{attribute.Name}}\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"{{entity.PluralName}}Localized\".\"{{attribute.Name}}\", ('##OPEN##' || COALESCE(\"{{entity.PluralName}}\".\"{{attribute.Name}}\", '')) || '##CLOSE##') AS \"{{attribute.Name}}\""))
			{{- end}}
			{{- end}}
			{{- for relationship in entity.Relationships }}
			{{- if  relationship.IsForeignKeyOnThisSide && (relationship.Relationship == "ZeroOrOne" || relationship.Relationship == "ExactlyOne") }}
			{{- relationshipName = GetNavigationPropertyName entity relationship}}
			.Select("{{entity.PluralName}}.{{relationshipName}}Id")
			{{-end}}
			{{- end }}
			{{- if entity.IsOwnedEntity && (entity.Keys | array.size > 0)}}
			.Select("{{entity.PluralName}}.{{entity.OwnerEntity.Name}}Id")
			{{- end }}
			{{- if !entity.IsOwnedEntity }}
			.Select("{{entity.PluralName}}.Etag")
			{{- end }}
			.LeftJoin(localizedEntityQuery, j => j.On("{{entity.PluralName}}Localized.{{entityKeys[0].Name}}", "{{entity.PluralName}}.{{entityKeys[0].Name}}"));

		return _sqlCompiler.Compile(entityQuery).ToString().Replace("##OPEN##", "[").Replace("##CLOSE##", "]");
	}
}