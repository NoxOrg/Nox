
using ClientApi.Application.Dto;
using Nox.Solution;
using ClientApi.Domain;
using ClientApi.Application.IntegrationEvents.StoreOwner;
using Nox.Infrastructure.Messaging;
using Nox.Application.Factories;

namespace ClientApi.Application.Commands;

/// <summary>
/// Example of fully override and implement a default command handler
/// </summary>
internal partial class CreateStoreOwnerCommandHandler
{
    private IOutboxRepository? _outboxRepository;

    public CreateStoreOwnerCommandHandler(
        Infrastructure.Persistence.AppDbContext dbContext,
        NoxSolution noxSolution,
        IEntityFactory<Store, StoreCreateDto, StoreUpdateDto> storefactory,
        IEntityFactory<StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory,
        IOutboxRepository outboxRepository)
        : base(dbContext, noxSolution, storefactory, entityFactory)
    {
        _outboxRepository = outboxRepository;
    }

    protected override async Task OnCompletedAsync(CreateStoreOwnerCommand request, StoreOwner entity)
    {
        if (entity.TemporaryOwnerName.Value == "unknow")
        {
            // Send a integration event to the outbox
          await _outboxRepository!.AddAsync(new UnknowStoreOwnerCreated(entity.Id.Value));
        }
    }
}