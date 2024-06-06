using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditFile : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public FileTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public IEnumerable<FileFormatType>? SupportedFileFormats { get; set; }

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
            SupportedFileFormats = TypeOptions.SupportedFileFormats;
        }
    }
}