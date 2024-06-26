﻿using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditPassword : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public PasswordTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public int MinLength { get; set; } = 0;

    [Parameter]
    public int MaxLength { get; set; } = 100;

    [Parameter]
    public int SaltLength { get; set; } = 100;

    [Parameter]
    public HashingAlgorithm HashingAlgorithm { get; set; } = HashingAlgorithm.SHA256;

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; } = false;

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            MinLength = TypeOptions.MinLength;
            MaxLength = TypeOptions.MaxLength;
            SaltLength = TypeOptions.SaltLength;
            HashingAlgorithm = TypeOptions.HashingAlgorithm;
        }
    }
}