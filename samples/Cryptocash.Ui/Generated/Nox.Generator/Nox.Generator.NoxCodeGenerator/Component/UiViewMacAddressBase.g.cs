using Microsoft.AspNetCore.Components;
using Nox.Types;
using System.Globalization;
using YamlDotNet.Core.Tokens;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewMacAddressBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public string MacAddress { get; set; }

        [Parameter]
        public MacAddressFormat MacAddressFormat { get; set; } = MacAddressFormat.ByteGroupWithColon;

        #endregion

        public string DisplayMacAddress()
        {
            return GetFormatted(MacAddressFormat);
        }

        private string GetFormatted(MacAddressFormat format)
        => format switch
        {
            MacAddressFormat.NoSeparator => MacAddress.ToString(CultureInfo.InvariantCulture),
            MacAddressFormat.ByteGroupWithColon => string.Join(":", SplitAddress(2)),
            MacAddressFormat.ByteGroupWithDash => string.Join("-", SplitAddress(2)),
            MacAddressFormat.DoubleByteGroupWithColon => string.Join(":", SplitAddress(4)),
            MacAddressFormat.DoubleByteGroupWithDot => string.Join(".", SplitAddress(4)),
            _ => throw new NotImplementedException()
        };

        private IEnumerable<string> SplitAddress(int chunkSize)
        => Enumerable.Range(0, MacAddress.Length / chunkSize).Select(i => MacAddress.Substring(i * chunkSize, chunkSize));

    }
}