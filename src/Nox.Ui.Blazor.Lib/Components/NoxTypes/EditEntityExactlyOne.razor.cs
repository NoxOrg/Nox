using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditEntityExactlyOne : ComponentBase
{

    #region Declarations

    [Parameter]
    public GenericEntityModel? Entity { get; set; }

    [Parameter]
    public string? Id { get; set; }

    public string? CurrentIdStr { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public List<GenericEntityModel> SelectionList { get; set; } = new();

    [Parameter]
    public EventCallback<GenericEntityModel> EntityChanged { get; set; }

    [Parameter]
    public EventCallback<string?> IdChanged { get; set; }

    #endregion

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        CurrentIdStr = Id;
    }

    protected async Task OnIdChanged(string newValue)
    {
        CurrentIdStr = newValue;

        if (!string.IsNullOrWhiteSpace(CurrentIdStr))
        {
            Entity = SelectionList.Find(Entity => !string.IsNullOrWhiteSpace(Entity.Id) && Entity.Id.ToString().Equals(CurrentIdStr));
            await EntityChanged.InvokeAsync(Entity);

            if (Entity != null)
            {
                Id = Entity.Id;
                await IdChanged.InvokeAsync(Id);
            }
        }
    }

    protected static string ErrorRequiredMessage(string? CurrentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, CurrentTitle);
    }
}