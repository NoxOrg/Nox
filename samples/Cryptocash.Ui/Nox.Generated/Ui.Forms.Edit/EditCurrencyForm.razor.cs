using Microsoft.AspNetCore.Components;
using MudBlazor;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Forms.Edit;

public partial class EditCurrencyForm : ComponentBase
{
    private bool IsLoading = false;
    private bool HasError = false;

    [Parameter]
    public CurrencyModel Currency { get; set; } = new();

    [Parameter]
    public EventCallback OnSubmit { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }
    
    [Parameter]
    public bool IsVisible { get; set; }

    [Parameter]
    public EventCallback<bool> IsVisibleChanged { get; set; }

    [Parameter]
    public DialogOptions EditDialogOptions { get; set; } = new()
        {
            FullWidth = true,
            BackgroundClass = "custom-dialog",
            BackdropClick = true,
            Position = DialogPosition.TopCenter,
            MaxWidth = MaxWidth.Large
        };

    private async Task OnSubmitClicked()
    {
        try
        {
            IsLoading = true;

            if (Currency != null)
            {
                var result = await CurrenciesService.UpdateAsync(Currency);

                if (result is null)
                    HasError = true;
                else
                {
                    ResetForm();
                    await OnSubmit.InvokeAsync();
                }
            } 
        }
        catch
        {
            HasError = true;
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task OnCancelClicked()
    {
        ResetForm();
        await OnCancel.InvokeAsync();
    }

    private void ResetForm()
    {
        HasError = false;
        IsLoading = false;
    }
}