﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using RatingProgram = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public record PartialUpdateRatingProgramCommand(System.Guid keyStoreId, System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <RatingProgramKeyDto?>;

public class PartialUpdateRatingProgramCommandHandler: PartialUpdateRatingProgramCommandHandlerBase
{
	public PartialUpdateRatingProgramCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<RatingProgram> entityMapper): base(dbContext,noxSolution, serviceProvider, entityMapper)
	{
	}
}
public class PartialUpdateRatingProgramCommandHandlerBase: CommandBase<PartialUpdateRatingProgramCommand, RatingProgram>, IRequestHandler<PartialUpdateRatingProgramCommand, RatingProgramKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<RatingProgram> EntityMapper { get; }

	public PartialUpdateRatingProgramCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<RatingProgram> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public virtual async Task<RatingProgramKeyDto?> Handle(PartialUpdateRatingProgramCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyStoreId = CreateNoxTypeForKey<RatingProgram,Nox.Types.Guid>("StoreId", request.keyStoreId);
		var keyId = CreateNoxTypeForKey<RatingProgram,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.RatingPrograms.FindAsync(keyStoreId, keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<RatingProgram>(), request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new RatingProgramKeyDto(entity.StoreId.Value, entity.Id.Value);
	}
}