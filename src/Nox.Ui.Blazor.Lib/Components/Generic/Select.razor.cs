using Microsoft.AspNetCore.Components;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.Generic;

public partial class Select : ComponentBase
{

    #region Declarations

    [Parameter]
    public SelectEntityModel? Entity { get; set; }

    [Parameter]
    public string? CurrentId { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public List<SelectEntityModel> SelectionList { get; set; } = new();

    [Parameter]
    public EventCallback<SelectEntityModel> EntityChanged { get; set; }

    [Parameter]
    public EventCallback<string?> IdChanged { get; set; }

    [Parameter]
    public bool Required { get; set; } = false;

    #endregion

    protected async Task OnIdChanged(string newValue)
    {
        CurrentId = newValue;

        if (!string.IsNullOrWhiteSpace(CurrentId))
        {
            Entity = SelectionList.Find(Entity => !string.IsNullOrWhiteSpace(Entity.Id) && Entity.Id.ToString().Equals(CurrentId));
            await EntityChanged.InvokeAsync(Entity);

            if (Entity != null)
            {
                await IdChanged.InvokeAsync(CurrentId);
            }
        }
    }

    protected static string ErrorRequiredMessage(string? CurrentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, CurrentTitle);
    }
}