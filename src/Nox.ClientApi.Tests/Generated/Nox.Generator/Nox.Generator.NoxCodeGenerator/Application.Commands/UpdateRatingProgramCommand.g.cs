﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public record UpdateRatingProgramCommand(System.Guid keyStoreId, System.Int64 keyId, RatingProgramUpdateDto EntityDto, System.Guid? Etag) : IRequest<RatingProgramKeyDto?>;

internal partial class UpdateRatingProgramCommandHandler : UpdateRatingProgramCommandHandlerBase
{
	public UpdateRatingProgramCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateRatingProgramCommandHandlerBase : CommandBase<UpdateRatingProgramCommand, RatingProgramEntity>, IRequestHandler<UpdateRatingProgramCommand, RatingProgramKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> _entityFactory;

	public UpdateRatingProgramCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<RatingProgramKeyDto?> Handle(UpdateRatingProgramCommand request, CancellationToken cancellationToken)
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

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new RatingProgramKeyDto(entity.StoreId.Value, entity.Id.Value);
	}
}