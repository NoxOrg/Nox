using ClientApi.Domain;

namespace ClientApi.Application.Commands;

/// <summary>
/// Example of adding additional properties to Dto used in commands 
/// </summary>
internal partial class CreateStoreCommandHandler
{
    /// <summary>
    /// Using the added property to do some logic in the request before executing the command
    /// </summary>
    /// <param name="request"></param>
    protected override void OnExecuting(CreateStoreCommand request)
    {
        if (request.EntityDto.IsTemporary) 
        {
            // do your code
        }
    }

    /// <summary>
    /// Using the added property to do some logic after the entity is created
    /// </summary>
    protected override Task OnCompletedAsync(CreateStoreCommand request, Store entity)
    {
        if (request.EntityDto.IsTemporary)
        {
            // do your code
            // Notify some onw that a temporary store was created
        }
        return Task.CompletedTask;
    }
}
