using System;
using System.Collections.Generic;
using System.Text;

namespace Nox.Types;

public class ValidationFailure
{
    public string Variable { get; private set; }
    public string ErrorMessage { get; private set; }

    public ValidationFailure(string variable, string errorMessage)
    {
        Variable = variable;
        ErrorMessage = errorMessage;
    }
}
