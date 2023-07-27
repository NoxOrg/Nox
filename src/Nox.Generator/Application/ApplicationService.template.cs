// Generated

#nullable enable

using System;
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.ODataNameSpace}};


namespace {{codeGeneratorState.ApplicationNameSpace}};

/// <summary>
/// ....
/// </summary>
public partial class {{className}} : I{{entity.Name}}ApplicationService
{
    public {{codeGeneratorState.Solution.Name}}DbContext DatabaseContext { get; }

    public {{className}}({{codeGeneratorState.Solution.Name}}DbContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }

    public virtual {{entity.Name}} Create({{entity.Name}}Dto odataModel)
    {
        var entity = new {{entity.Name}}();
        // TODO Setup Entity including Id
        DatabaseContext.{{entity.PluralName}}.Add(entity);
        return entity;
    }

    public virtual {{entity.Name}} Update({{entity.Name}}Dto odataModel)
    {
        // TODO Fin Entity by id
        // TODO Setup Entity including Id
        throw new NotImplementedException();
    }
}

public interface I{{entity.Name}}ApplicationService
{
    /// <summary>
    /// Creates an {{entity.Name}} from a {{entity.Name}}Dto
    /// </summary>
    {{entity.Name}} Create({{entity.Name}}Dto odataModel);

    /// <summary>
    /// Updates an {{entity.Name}} from a {{entity.Name}}Dto
    /// </summary>
    {{entity.Name}} Update({{entity.Name}}Dto odataModel);
}
