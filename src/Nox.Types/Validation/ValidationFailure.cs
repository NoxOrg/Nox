namespace Nox.Types;

public sealed class ValidationFailure
{
    public string Variable { get; private set; }
    public string ErrorMessage { get; private set; }

    public ValidationFailure(string variable, string errorMessage)
    {
        Variable = variable;
        ErrorMessage = errorMessage;
    }
}
