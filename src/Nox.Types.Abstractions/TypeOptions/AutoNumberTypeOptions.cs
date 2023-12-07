namespace Nox.Types;

public class AutoNumberTypeOptions : INoxTypeOptions
{
    public int StartsAt { get; set; } = 1;
    public int IncrementsBy { get; set; } = 1;
}