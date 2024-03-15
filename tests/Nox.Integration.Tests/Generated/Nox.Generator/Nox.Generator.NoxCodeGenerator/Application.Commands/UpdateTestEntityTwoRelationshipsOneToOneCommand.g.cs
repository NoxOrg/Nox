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
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityTwoRelationshipsOneToOneCommand(System.String keyId, TestEntityTwoRelationshipsOneToOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityTwoRelationshipsOneToOneKeyDto>;

internal partial class UpdateTestEntityTwoRelationshipsOneToOneCommandHandler : UpdateTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public UpdateTestEntityTwoRelationshipsOneToOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<UpdateTestEntityTwoRelationshipsOneToOneCommand, TestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler<UpdateTestEntityTwoRelationshipsOneToOneCommand, TestEntityTwoRelationshipsOneToOneKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToOneKeyDto> Handle(UpdateTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne>()
            .Where(x => x.Id == Dto.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToOne",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityTwoRelationshipsOneToOneKeyDto(entity.Id.Value);
	}
}