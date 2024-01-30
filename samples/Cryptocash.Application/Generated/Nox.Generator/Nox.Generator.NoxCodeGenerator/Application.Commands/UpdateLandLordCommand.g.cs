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
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public partial record UpdateLandLordCommand(System.Guid keyId, LandLordUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<LandLordKeyDto>;

internal partial class UpdateLandLordCommandHandler : UpdateLandLordCommandHandlerBase
{
	public UpdateLandLordCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateLandLordCommandHandlerBase : CommandBase<UpdateLandLordCommand, LandLordEntity>, IRequestHandler<UpdateLandLordCommand, LandLordKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> EntityFactory { get; }
	protected UpdateLandLordCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<LandLordKeyDto> Handle(UpdateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<LandLord>()
            .Where(x => x.Id == Dto.LandLordMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("LandLord",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new LandLordKeyDto(entity.Id.Value);
	}
}