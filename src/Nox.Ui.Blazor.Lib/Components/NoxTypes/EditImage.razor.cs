using Microsoft.AspNetCore.Components;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditImage : ComponentBase
{
    [Parameter]
    public ImageModel? Image { get; set; }

    [Parameter]
    public EventCallback<ImageModel?> ImageChanged { get; set; }
}