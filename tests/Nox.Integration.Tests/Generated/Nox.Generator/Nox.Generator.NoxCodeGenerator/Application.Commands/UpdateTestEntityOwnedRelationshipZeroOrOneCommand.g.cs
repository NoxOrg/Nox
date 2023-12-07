﻿﻿// Generated

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
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityOwnedRelationshipZeroOrOneCommand(System.String keyId, TestEntityOwnedRelationshipZeroOrOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityOwnedRelationshipZeroOrOneKeyDto?>;

internal partial class UpdateTestEntityOwnedRelationshipZeroOrOneCommandHandler : UpdateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase
{
	public UpdateTestEntityOwnedRelationshipZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase : CommandBase<UpdateTestEntityOwnedRelationshipZeroOrOneCommand, TestEntityOwnedRelationshipZeroOrOneEntity>, IRequestHandler<UpdateTestEntityOwnedRelationshipZeroOrOneCommand, TestEntityOwnedRelationshipZeroOrOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> _entityFactory;

	protected UpdateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipZeroOrOneKeyDto?> Handle(UpdateTestEntityOwnedRelationshipZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOwnedRelationshipZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		await DbContext.Entry(entity).Reference(x => x.SecondTestEntityOwnedRelationshipZeroOrOne).LoadAsync();

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityOwnedRelationshipZeroOrOneKeyDto(entity.Id.Value);
	}
}

public class UpdateTestEntityOwnedRelationshipZeroOrOneValidator : AbstractValidator<UpdateTestEntityOwnedRelationshipZeroOrOneCommand>
{
    public UpdateTestEntityOwnedRelationshipZeroOrOneValidator()
    {
    }
}