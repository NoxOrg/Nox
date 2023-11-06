﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public partial record UpdateLandLordCommand(System.Int64 keyId, LandLordUpdateDto EntityDto, System.Guid? Etag) : IRequest<LandLordKeyDto?>;

internal partial class UpdateLandLordCommandHandler : UpdateLandLordCommandHandlerBase
{
	public UpdateLandLordCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateLandLordCommandHandlerBase : CommandBase<UpdateLandLordCommand, LandLordEntity>, IRequestHandler<UpdateLandLordCommand, LandLordKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> _entityFactory;

	public UpdateLandLordCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<LandLordKeyDto?> Handle(UpdateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.LandLordMetadata.CreateId(request.keyId);

		var entity = await DbContext.LandLords.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
		var vendingMachinesEntities = new List<VendingMachine>();
		foreach(var relatedEntityId in request.EntityDto.VendingMachinesId)
		{
			var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				vendingMachinesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachines", relatedEntityId.ToString());
		}
		entity.UpdateRefToVendingMachines(vendingMachinesEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new LandLordKeyDto(entity.Id.Value);
	}
}