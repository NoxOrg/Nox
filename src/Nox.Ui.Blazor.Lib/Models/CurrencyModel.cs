﻿using Nox.Types;
namespace Nox.Ui.Blazor.Lib.Models;

public class CurrencyModel
{
    public CurrencyModel()
    {
    }

    public CurrencyModel(string? id, string? name)
    {
        Id = id;
        Name = name;
    }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? CurrencyCodeStr { get; set; }
}
