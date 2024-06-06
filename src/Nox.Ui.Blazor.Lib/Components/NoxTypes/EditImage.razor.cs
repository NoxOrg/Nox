using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditImage : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public ImageModel? Image { get; set; }

    [Parameter]
    public EventCallback<ImageModel?> ImageChanged { get; set; }

    [Parameter]
    public ImageTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public IEnumerable<ImageFormatType>? ImageFormatTypes { get; set; }

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
            ImageFormatTypes = TypeOptions.ImageFormatTypes;
        }
    }
}