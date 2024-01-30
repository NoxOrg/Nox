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
using TestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityTwoRelationshipsOneToManyCommand(System.String keyId, TestEntityTwoRelationshipsOneToManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityTwoRelationshipsOneToManyKeyDto>;

internal partial class UpdateTestEntityTwoRelationshipsOneToManyCommandHandler : UpdateTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public UpdateTestEntityTwoRelationshipsOneToManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<UpdateTestEntityTwoRelationshipsOneToManyCommand, TestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<UpdateTestEntityTwoRelationshipsOneToManyCommand, TestEntityTwoRelationshipsOneToManyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToManyKeyDto> Handle(UpdateTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestEntityTwoRelationshipsOneToMany>()
            .Where(x => x.Id == Dto.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityTwoRelationshipsOneToManyKeyDto(entity.Id.Value);
	}
}