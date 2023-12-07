﻿
﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;
public partial record PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipZeroOrManyKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?>;
internal partial class PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler: PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase: CommandBase<PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, SecondTestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler <PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto> _entityFactory;

	protected PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
		AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?> Handle(PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.TestEntityOwnedRelationshipZeroOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await _dbContext.Entry(parentEntity).Collection(p => p.SecondTestEntityOwnedRelationshipZeroOrManies).LoadAsync(cancellationToken);
		var ownedId = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.SecondTestEntityOwnedRelationshipZeroOrManies.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		_dbContext.Entry(entity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOwnedRelationshipZeroOrManyKeyDto(entity.Id.Value);
	}
}