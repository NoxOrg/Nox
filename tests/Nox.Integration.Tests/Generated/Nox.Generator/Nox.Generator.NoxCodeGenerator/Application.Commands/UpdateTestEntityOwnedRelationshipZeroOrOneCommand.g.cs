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
using TestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityOwnedRelationshipZeroOrOneCommand(System.String keyId, TestEntityOwnedRelationshipZeroOrOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityOwnedRelationshipZeroOrOneKeyDto>;

internal partial class UpdateTestEntityOwnedRelationshipZeroOrOneCommandHandler : UpdateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase
{
	public UpdateTestEntityOwnedRelationshipZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase : CommandBase<UpdateTestEntityOwnedRelationshipZeroOrOneCommand, TestEntityOwnedRelationshipZeroOrOneEntity>, IRequestHandler<UpdateTestEntityOwnedRelationshipZeroOrOneCommand, TestEntityOwnedRelationshipZeroOrOneKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipZeroOrOneKeyDto> Handle(UpdateTestEntityOwnedRelationshipZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne>()
            .Where(x => x.Id == Dto.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(request.keyId))
			.Include(e => e.SecondTestEntityOwnedRelationshipZeroOrOne)
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrOne",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityOwnedRelationshipZeroOrOneKeyDto(entity.Id.Value);
	}
}

public class UpdateTestEntityOwnedRelationshipZeroOrOneValidator : AbstractValidator<UpdateTestEntityOwnedRelationshipZeroOrOneCommand>
{
    public UpdateTestEntityOwnedRelationshipZeroOrOneValidator()
    {
    }
}