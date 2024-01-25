﻿using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using MudBlazor.Charts;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.Generic;

public partial class SelectList : ComponentBase
{

    #region Declarations

    [Parameter]
    public List<SelectEntityModel> EntityList { get; set; } = new();

    public string? CurrentIdList { get; set; }

    public string? DisplaySelectedList { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public List<SelectEntityModel> SelectionList { get; set; } = new();

    [Parameter]
    public EventCallback<List<SelectEntityModel>?> EntityListChanged { get; set; }

    [Parameter]
    public bool Required { get; set; } = false;

    #endregion

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        if (EntityList.Any())
        {
            CurrentIdList = string.Join(",", EntityList.Select(Entity => Entity.Id));
        }
    }

    protected async Task OnIdChanged(string newValue)
    {

        CurrentIdList = newValue;
        IEnumerable<string> selectedIdList = new List<string>();
        if (!string.IsNullOrWhiteSpace(CurrentIdList))
        {
            selectedIdList = CurrentIdList.Split(',').Select(Id => Id.Trim()).ToList();
        }

        EntityList = new();

        if (selectedIdList.Any())
        {
            foreach (string currentId in selectedIdList)
            {
                SelectEntityModel? entity = SelectionList.Find(Entity => 
                !string.IsNullOrWhiteSpace(Entity.Id)
                && Entity.Id.ToString().Equals(currentId));

                if (entity != null)
                {
                    EntityList.Add(entity);
                }
            }
        }

        if (EntityList!.Any())
        {
            DisplaySelectedList = string.Join(", ", EntityList.Select(Entity => Entity.Name));
        }
        else
        {
            DisplaySelectedList = string.Empty;
        }        

        await EntityListChanged.InvokeAsync(EntityList);
    }

    protected static string ErrorRequiredMessage(string? CurrentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, CurrentTitle);
    }
}