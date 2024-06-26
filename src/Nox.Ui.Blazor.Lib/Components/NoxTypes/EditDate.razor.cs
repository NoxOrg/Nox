﻿using Microsoft.AspNetCore.Components;
using Nox.Types;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditDate : ComponentBase
{
    #region Declarations

    [Parameter]
    public System.DateTime? Date { get; set; }

    [Parameter]
    public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string Format { get; set; } = "dd/MM/yyyy";

    [Parameter]
    public EventCallback<System.DateTime?> DateChanged { get; set; }

    [Parameter]
    public DateTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public System.DateTime MinValue { get; set; }

    [Parameter]
    public System.DateTime MaxValue { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; } = false;

    #endregion

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            MinValue = TypeOptions.MinValue;
            MaxValue = TypeOptions.MaxValue;
        }
    }

    protected async Task OnDateChanged(string newValue)
    {
        if (System.DateTime.TryParse(newValue, CultureInfo, out System.DateTime currentDate))
        {
            Date = currentDate;
            await DateChanged.InvokeAsync(Date);
        }
        else
        {
            Date = null;
            await DateChanged.InvokeAsync(Date);
        }
    }

    protected static string ErrorRequiredMessage(string? currentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, currentTitle).Trim();
    }

    public string DisplayPlaceholder
    {
        get
        {
            return Format.ToUpper();
        }
    }
}