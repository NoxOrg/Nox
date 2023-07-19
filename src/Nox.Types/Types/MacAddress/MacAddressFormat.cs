namespace Nox.Types;

public enum MacAddressFormat
{
    /// <summary>
    /// Mac address format without separator (XXXXXXXXXXXX)
    /// </summary>
    NoSeparator = 0,

    /// <summary>
    /// Mac address format with byte grouping and colon separator (XX:XX:XX:XX:XX:XX)
    /// </summary>
    ByteGroupWithColon = 1,

    /// <summary>
    /// Mac address format with byte grouping and dash separator (XX-XX-XX-XX-XX-XX)
    /// </summary>
    ByteGroupWithDash = 2,

    /// <summary>
    /// Mac address format with double byte and dot separator (XXXX.XXXX.XXXX)
    /// </summary>
    DoubleByteGroupWithDot = 3,

    /// <summary>
    /// Mac address format with double byte colon separator (XXXX:XXXX:XXXX)
    /// </summary>
    DoubleByteGroupWithColon = 4
}
