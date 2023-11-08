﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;
public record CreateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto EntityDto, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?>;

internal partial class CreateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommandHandler : CreateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public CreateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase : CommandBase<CreateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommand, SecondTestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler<CreateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommand, SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> _entityFactory;

	public CreateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?> Handle(CreateSecondTestEntityOwnedRelationshipZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.TestEntityOwnedRelationshipZeroOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CreateRefToSecondTestEntityOwnedRelationshipZeroOrMany(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOwnedRelationshipZeroOrManyKeyDto(entity.Id.Value);
	}
}