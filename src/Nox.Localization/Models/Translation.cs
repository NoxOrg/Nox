namespace Nox.Localization.Models;

public class Translation
{
    public long Id { get; set; }
    public string Key { get; set; } = default!;
    public string Text { get; set; } = default!;
    public string CultureCode { get; set; } = default!;
    public string ResourceKey { get; set; } = default!;
    public bool Validated { get; set; } = false;
    public DateTime LastUpdatedUtc { get; set; } = default;
}
