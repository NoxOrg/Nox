// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateVendingMachineCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <VendingMachineKeyDto>;

internal partial class PartialUpdateVendingMachineCommandHandler : PartialUpdateVendingMachineCommandHandlerBase
{
	public PartialUpdateVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateVendingMachineCommandHandlerBase : CommandBase<PartialUpdateVendingMachineCommand, VendingMachineEntity>, IRequestHandler<PartialUpdateVendingMachineCommand, VendingMachineKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> EntityFactory { get; }

	public PartialUpdateVendingMachineCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<VendingMachineKeyDto> Handle(PartialUpdateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.keyId);

		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new VendingMachineKeyDto(entity.Id.Value);
	}
}