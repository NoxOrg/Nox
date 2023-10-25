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
using SecondTestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;
public record CreateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipOneOrManyCreateDto EntityDto, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipOneOrManyKeyDto?>;

internal partial class CreateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandler : CreateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public CreateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipOneOrManyEntity, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<CreateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand, SecondTestEntityOwnedRelationshipOneOrManyEntity>, IRequestHandler<CreateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand, SecondTestEntityOwnedRelationshipOneOrManyKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityOwnedRelationshipOneOrManyEntity, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> _entityFactory;

	public CreateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipOneOrManyEntity, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<SecondTestEntityOwnedRelationshipOneOrManyKeyDto?> Handle(CreateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.TestEntityOwnedRelationshipOneOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CreateRefToSecondTestEntityOwnedRelationshipOneOrMany(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(entity.Id.Value);
	}
}