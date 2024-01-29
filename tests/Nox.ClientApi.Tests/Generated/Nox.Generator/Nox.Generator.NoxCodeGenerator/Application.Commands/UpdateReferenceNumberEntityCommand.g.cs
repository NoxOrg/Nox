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
using ReferenceNumberEntityEntity = ClientApi.Domain.ReferenceNumberEntity;

namespace ClientApi.Application.Commands;

public partial record UpdateReferenceNumberEntityCommand(System.String keyId, ReferenceNumberEntityUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<ReferenceNumberEntityKeyDto>;

internal partial class UpdateReferenceNumberEntityCommandHandler : UpdateReferenceNumberEntityCommandHandlerBase
{
	public UpdateReferenceNumberEntityCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateReferenceNumberEntityCommandHandlerBase : CommandBase<UpdateReferenceNumberEntityCommand, ReferenceNumberEntityEntity>, IRequestHandler<UpdateReferenceNumberEntityCommand, ReferenceNumberEntityKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> EntityFactory { get; }
	protected UpdateReferenceNumberEntityCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ReferenceNumberEntityKeyDto> Handle(UpdateReferenceNumberEntityCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<ReferenceNumberEntity>()
            .Where(x => x.Id == Dto.ReferenceNumberEntityMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("ReferenceNumberEntity",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		//Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new ReferenceNumberEntityKeyDto(entity.Id.Value);
	}
}