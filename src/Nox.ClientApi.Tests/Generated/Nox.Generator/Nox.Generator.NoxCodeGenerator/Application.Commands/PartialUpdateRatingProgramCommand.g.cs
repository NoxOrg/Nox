﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public record PartialUpdateRatingProgramCommand(System.Guid keyStoreId, System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <RatingProgramKeyDto?>;

internal class PartialUpdateRatingProgramCommandHandler : PartialUpdateRatingProgramCommandHandlerBase
{
	public PartialUpdateRatingProgramCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateRatingProgramCommandHandlerBase : CommandBase<PartialUpdateRatingProgramCommand, RatingProgramEntity>, IRequestHandler<PartialUpdateRatingProgramCommand, RatingProgramKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> EntityFactory { get; }

	public PartialUpdateRatingProgramCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<RatingProgramKeyDto?> Handle(PartialUpdateRatingProgramCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyStoreId = ClientApi.Domain.RatingProgramMetadata.CreateStoreId(request.keyStoreId);
		var keyId = ClientApi.Domain.RatingProgramMetadata.CreateId(request.keyId);

		var entity = await DbContext.RatingPrograms.FindAsync(keyStoreId, keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new RatingProgramKeyDto(entity.StoreId.Value, entity.Id.Value);
	}
}