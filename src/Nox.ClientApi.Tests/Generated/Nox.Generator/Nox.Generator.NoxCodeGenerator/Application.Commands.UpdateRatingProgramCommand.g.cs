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
using RatingProgram = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public record UpdateRatingProgramCommand(System.Guid keyStoreId, System.Int64 keyId, RatingProgramUpdateDto EntityDto, System.Guid? Etag) : IRequest<RatingProgramKeyDto?>;

public partial class UpdateRatingProgramCommandHandler: UpdateRatingProgramCommandHandlerBase
{
	public UpdateRatingProgramCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<RatingProgram, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

public abstract class UpdateRatingProgramCommandHandlerBase: CommandBase<UpdateRatingProgramCommand, RatingProgram>, IRequestHandler<UpdateRatingProgramCommand, RatingProgramKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<RatingProgram, RatingProgramCreateDto, RatingProgramUpdateDto> _entityFactory;

	public UpdateRatingProgramCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<RatingProgram, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<RatingProgramKeyDto?> Handle(UpdateRatingProgramCommand request, CancellationToken cancellationToken)
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

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new RatingProgramKeyDto(entity.StoreId.Value, entity.Id.Value);
	}
}