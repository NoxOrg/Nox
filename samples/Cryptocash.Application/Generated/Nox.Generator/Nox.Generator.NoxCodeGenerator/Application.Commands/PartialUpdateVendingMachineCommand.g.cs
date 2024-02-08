// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateVendingMachineCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <VendingMachineKeyDto>;

internal partial class PartialUpdateVendingMachineCommandHandler : PartialUpdateVendingMachineCommandHandlerBase
{
	public PartialUpdateVendingMachineCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateVendingMachineCommandHandlerBase : CommandBase<PartialUpdateVendingMachineCommand, VendingMachineEntity>, IRequestHandler<PartialUpdateVendingMachineCommand, VendingMachineKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> EntityFactory { get; }
	
	public PartialUpdateVendingMachineCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<VendingMachineKeyDto> Handle(PartialUpdateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.VendingMachineMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Cryptocash.Domain.VendingMachine>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new VendingMachineKeyDto(entity.Id.Value);
	}
}