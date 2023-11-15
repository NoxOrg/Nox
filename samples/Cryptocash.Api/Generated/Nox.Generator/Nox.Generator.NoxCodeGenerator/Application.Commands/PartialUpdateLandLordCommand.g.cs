﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public record PartialUpdateLandLordCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <LandLordKeyDto?>;

internal class PartialUpdateLandLordCommandHandler : PartialUpdateLandLordCommandHandlerBase
{
	public PartialUpdateLandLordCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateLandLordCommandHandlerBase : CommandBase<PartialUpdateLandLordCommand, LandLordEntity>, IRequestHandler<PartialUpdateLandLordCommand, LandLordKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> EntityFactory { get; }

	public PartialUpdateLandLordCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<LandLordKeyDto?> Handle(PartialUpdateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.LandLordMetadata.CreateId(request.keyId);

		var entity = await DbContext.LandLords.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new LandLordKeyDto(entity.Id.Value);
	}
}