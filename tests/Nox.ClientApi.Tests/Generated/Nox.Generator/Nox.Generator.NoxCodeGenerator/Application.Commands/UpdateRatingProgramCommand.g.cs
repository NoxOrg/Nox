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


using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public partial record UpdateRatingProgramCommand(System.Guid keyStoreId, System.Int64 keyId, RatingProgramUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<RatingProgramKeyDto>;

internal partial class UpdateRatingProgramCommandHandler : UpdateRatingProgramCommandHandlerBase
{
	public UpdateRatingProgramCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateRatingProgramCommandHandlerBase : CommandBase<UpdateRatingProgramCommand, RatingProgramEntity>, IRequestHandler<UpdateRatingProgramCommand, RatingProgramKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> EntityFactory { get; }
	protected UpdateRatingProgramCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<RatingProgramKeyDto> Handle(UpdateRatingProgramCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<ClientApi.Domain.RatingProgram>()
            .Where(x => x.StoreId == Dto.RatingProgramMetadata.CreateStoreId(request.keyStoreId))
            .Where(x => x.Id == Dto.RatingProgramMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("RatingProgram",  "keyStoreId, keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new RatingProgramKeyDto(entity.StoreId.Value, entity.Id.Value);
	}
}