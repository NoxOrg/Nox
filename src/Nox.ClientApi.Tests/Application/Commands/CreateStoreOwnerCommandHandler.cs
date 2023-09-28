
using ClientApi.Application.Dto;
using Nox.Factories;
using Nox.Messaging;
using Nox.Solution;
using ClientApi.Domain;
using ClientApi.Application.IntegrationEvents.StoreOwner;

namespace ClientApi.Application.Commands;

/// <summary>
/// Example of fully override and implement a default command handler
/// </summary>
internal partial class CreateStoreOwnerCommandHandler 
{
    private IOutboxRepository? _outboxRepository;

    public CreateStoreOwnerCommandHandler(
        Infrastructure.Persistence.ClientApiDbContext dbContext,
        NoxSolution noxSolution,
        IEntityFactory<Store, StoreCreateDto, StoreUpdateDto> storefactory,
        IEntityFactory<StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory,
        IServiceProvider serviceProvider,
        IOutboxRepository outboxRepository)
        : base(dbContext, noxSolution, storefactory, entityFactory, serviceProvider)
    {
        _outboxRepository = outboxRepository;
    }

    public override async Task<StoreOwnerKeyDto> Handle(CreateStoreOwnerCommand request, CancellationToken cancellationToken)
    {
        /* Fully Implement the handler if needed */

        // Send a integration event to the outbox
        // Mass transit is failing in the CI build
        //await _outboxRepository!.AddAsync(new CustomStoreOwnerCreated());

        return await base.Handle(request, cancellationToken);        
    }
}