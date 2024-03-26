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
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityOwnedRelationshipExactlyOneCommand(System.String keyId, TestEntityOwnedRelationshipExactlyOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityOwnedRelationshipExactlyOneKeyDto>;

internal partial class UpdateTestEntityOwnedRelationshipExactlyOneCommandHandler : UpdateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public UpdateTestEntityOwnedRelationshipExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<UpdateTestEntityOwnedRelationshipExactlyOneCommand, TestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler<UpdateTestEntityOwnedRelationshipExactlyOneCommand, TestEntityOwnedRelationshipExactlyOneKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipExactlyOneKeyDto> Handle(UpdateTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne>()
            .Where(x => x.Id == Dto.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.keyId))
			.Include(e => e.SecEntityOwnedRelExactlyOne)
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipExactlyOne",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityOwnedRelationshipExactlyOneKeyDto(entity.Id.Value);
	}
}

public class UpdateTestEntityOwnedRelationshipExactlyOneValidator : AbstractValidator<UpdateTestEntityOwnedRelationshipExactlyOneCommand>
{
    public UpdateTestEntityOwnedRelationshipExactlyOneValidator()
    {
    }
}