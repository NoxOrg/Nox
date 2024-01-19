using Nox.Types;
namespace Nox.Ui.Blazor.Lib.Models;

public class GenericEntityModel
{
    public GenericEntityModel()
    {
    }

    public GenericEntityModel(string? id, string? name)
    {
        Id = id;
        Name = name;
    }

    public string? Id { get; set; }

    public string? Name { get; set; }
}
