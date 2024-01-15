using Nox.Types;

namespace Nox.Application.Dto;

/// <summary>
/// Base Implementation for a Nox EntityDto
/// </summary>
public abstract class EntityDtoBase
{
    public static void CollectValidationExceptions<T>(string propertyName, Func<T> createAction, Dictionary<string, IEnumerable<string>> validationResult)
    {
        try
        {
            createAction();
        }
        catch (NoxTypeValidationException ex)
        {
            validationResult.Add(propertyName, ex.Errors.Select(x => x.ErrorMessage));
        }
    }
}
