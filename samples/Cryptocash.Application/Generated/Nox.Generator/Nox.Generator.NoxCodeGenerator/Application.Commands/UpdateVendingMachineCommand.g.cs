﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public partial record UpdateVendingMachineCommand(System.Guid keyId, VendingMachineUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<VendingMachineKeyDto>;

internal partial class UpdateVendingMachineCommandHandler : UpdateVendingMachineCommandHandlerBase
{
	public UpdateVendingMachineCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateVendingMachineCommandHandlerBase : CommandBase<UpdateVendingMachineCommand, VendingMachineEntity>, IRequestHandler<UpdateVendingMachineCommand, VendingMachineKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> EntityFactory { get; }
	protected UpdateVendingMachineCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachineEntity, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<VendingMachineKeyDto> Handle(UpdateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<Cryptocash.Domain.VendingMachine>()
            .Where(x => x.Id == Dto.VendingMachineMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		Repository.Update(entity);
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new VendingMachineKeyDto(entity.Id.Value);
	}
}