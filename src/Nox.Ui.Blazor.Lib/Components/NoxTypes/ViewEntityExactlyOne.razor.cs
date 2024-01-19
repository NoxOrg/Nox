using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewEntityExactlyOne : ComponentBase
{

    #region Declarations

    [Parameter]
    public GenericEntityModel? Entity { get; set; }

    #endregion

    public string DisplayEntity
    {
        get
        {
            if (Entity != null
                && !String.IsNullOrWhiteSpace(Entity.Name))
            {
                return Entity.Name;
            }

            return String.Empty;
        }
    }
}