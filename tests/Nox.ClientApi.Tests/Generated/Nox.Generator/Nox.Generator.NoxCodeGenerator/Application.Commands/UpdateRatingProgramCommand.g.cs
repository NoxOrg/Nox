﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public partial record UpdateRatingProgramCommand(System.Guid keyStoreId, System.Int64 keyId, RatingProgramUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<RatingProgramKeyDto>;

internal partial class UpdateRatingProgramCommandHandler : UpdateRatingProgramCommandHandlerBase
{
	public UpdateRatingProgramCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateRatingProgramCommandHandlerBase : CommandBase<UpdateRatingProgramCommand, RatingProgramEntity>, IRequestHandler<UpdateRatingProgramCommand, RatingProgramKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> _entityFactory;
	protected UpdateRatingProgramCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<RatingProgramKeyDto> Handle(UpdateRatingProgramCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyStoreId = Dto.RatingProgramMetadata.CreateStoreId(request.keyStoreId);
		var keyId = Dto.RatingProgramMetadata.CreateId(request.keyId);

		var entity = await DbContext.RatingPrograms.FindAsync(keyStoreId, keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("RatingProgram",  $"{keyStoreId.ToString()}, {keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new RatingProgramKeyDto(entity.StoreId.Value, entity.Id.Value);
	}
}