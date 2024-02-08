using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Cryptocash.Ui.Forms.Add;

public partial class AddCommissionForm : ComponentBase
{
    [Parameter]
    public EventCallback OnSubmit { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }
    
    [Parameter]
    public bool IsVisible { get; set; }

    [Parameter]
    public EventCallback<bool> IsVisibleChanged { get; set; }

    [Parameter]
    public DialogOptions AddDialogOptions { get; set; } = new()
        {
            FullWidth = true,
            ClassBackground = "custom-dialog",
            DisableBackdropClick = true,
            Position = DialogPosition.TopCenter,
            MaxWidth = MaxWidth.Large
        };

    private async Task OnSubmitClicked()
    {
        await OnSubmit.InvokeAsync();
    }

    private async Task OnCancelClicked()
    {
        await OnCancel.InvokeAsync();
    }
}