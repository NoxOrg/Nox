using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewMacAddress : ComponentBase
{
    #region Declarations

    [Parameter]
    public string? MacAddress { get; set; }

    [Parameter]
    public MacAddressFormat MacAddressFormat { get; set; } = MacAddressFormat.ByteGroupWithColon;

    #endregion

    public string DisplayMacAddress()
    {
        return GetFormatted(MacAddressFormat).ToUpper();
    }

    private string GetFormatted(MacAddressFormat format)
    => format switch
    {
        MacAddressFormat.NoSeparator => MacAddress!.ToString(CultureInfo.InvariantCulture),
        MacAddressFormat.ByteGroupWithColon => string.Join(":", SplitAddress(2)),
        MacAddressFormat.ByteGroupWithDash => string.Join("-", SplitAddress(2)),
        MacAddressFormat.DoubleByteGroupWithColon => string.Join(":", SplitAddress(4)),
        MacAddressFormat.DoubleByteGroupWithDot => string.Join(".", SplitAddress(4)),
        _ => throw new NotImplementedException()
    };

    private IEnumerable<string> SplitAddress(int chunkSize)
    => Enumerable.Range(0, MacAddress!.Length / chunkSize).Select(i => MacAddress.Substring(i * chunkSize, chunkSize));
}