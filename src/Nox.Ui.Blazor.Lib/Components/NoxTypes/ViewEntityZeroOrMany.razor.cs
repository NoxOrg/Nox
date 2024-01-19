using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;
using System.Text;
using System.Linq;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewEntityZeroOrMany : ComponentBase
{

    #region Declarations

    [Parameter]
    public List<GenericEntityModel>? EntityList { get; set; }

    #endregion

    public string DisplayEntityList
    {
        get
        {
            StringBuilder ReturnEntityList = new();

            if (EntityList != null
                && EntityList.Count > 0)
            {
                bool Fresh = true;
                foreach (var CurrentEntity in from GenericEntityModel CurrentEntity in EntityList
                                              where !String.IsNullOrWhiteSpace(CurrentEntity.Name)
                                              select CurrentEntity)
                {
                    if (!Fresh)
                    {
                        ReturnEntityList.Append(", ");
                    }

                    ReturnEntityList.Append(CurrentEntity.Name);
                    Fresh = false;
                }
            }

            return ReturnEntityList.ToString();
        }
    }
}