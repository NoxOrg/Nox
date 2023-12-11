namespace Nox.Yaml.Validation;

public class ValidationResult
{
    public bool IsValid => Errors.Count == 0;

    public List<ValidationFailure> Errors { get; private set; } = new();

    public void AddError(string variable, string errorMessage)
    {
        Errors.Add(new ValidationFailure(variable, errorMessage));
    }
}
