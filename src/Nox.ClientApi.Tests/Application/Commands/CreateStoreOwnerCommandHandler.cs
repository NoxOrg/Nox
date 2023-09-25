
using ClientApi.Application.Dto;


namespace ClientApi.Application.Commands;

/// <summary>
/// Example of fully override and implement a default command handler
/// </summary>
internal partial class CreateStoreOwnerCommandHandler 
{    
    public override async Task<StoreOwnerKeyDto> Handle(CreateStoreOwnerCommand request, CancellationToken cancellationToken)
    {
        /* Fully Implement the handler if needed */
        return await base.Handle(request, cancellationToken);
    }
}