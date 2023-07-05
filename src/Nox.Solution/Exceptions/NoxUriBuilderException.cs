using System;

namespace Nox.Solution.Exceptions;

[Serializable]
public class NoxUriBuilderException: Exception
{
    public NoxUriBuilderException(string message): base(message)
    {
            
    }
        
    public NoxUriBuilderException(string message, Exception innerException): base(message, innerException)
    {
        
    }
}