﻿using Microsoft.AspNetCore.Components;
using MudBlazor;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Forms.Add;

public partial class AddVendingMachineForm : ComponentBase
{
    private VendingMachineModel VendingMachine = new();
    private bool IsLoading = false;
    private bool HasError = false;

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
            var result = await VendingMachinesService.CreateAsync(VendingMachine);

            if (result is null)
                HasError = true;
            else
            {
                ResetForm();
                await OnSubmit.InvokeAsync();
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
        VendingMachine = new();
        HasError = false;
        IsLoading = false;
    }
}