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


using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecondTestEntityTwoRelationshipsOneToManyCommand(System.String keyId, SecondTestEntityTwoRelationshipsOneToManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<SecondTestEntityTwoRelationshipsOneToManyKeyDto>;

internal partial class UpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandler : UpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public UpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<UpdateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> EntityFactory { get; }
	protected UpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToManyKeyDto> Handle(UpdateSecondTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<SecondTestEntityTwoRelationshipsOneToMany>()
            .Where(x => x.Id == Dto.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		//Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new SecondTestEntityTwoRelationshipsOneToManyKeyDto(entity.Id.Value);
	}
}