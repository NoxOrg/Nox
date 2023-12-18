﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecEntityOwnedRelZeroOrManyEntity = TestWebApp.Domain.SecEntityOwnedRelZeroOrMany;

namespace TestWebApp.Application.Commands;
public partial record PartialUpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyKeyDto ParentKeyDto, SecEntityOwnedRelZeroOrManyKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecEntityOwnedRelZeroOrManyKeyDto>;
internal partial class PartialUpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler: PartialUpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public PartialUpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelZeroOrManyEntity, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase: CommandBase<PartialUpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, SecEntityOwnedRelZeroOrManyEntity>, IRequestHandler <PartialUpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, SecEntityOwnedRelZeroOrManyKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<SecEntityOwnedRelZeroOrManyEntity, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> _entityFactory;

	protected PartialUpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
		AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelZeroOrManyEntity, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecEntityOwnedRelZeroOrManyKeyDto> Handle(PartialUpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.TestEntityOwnedRelationshipZeroOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrMany",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Collection(p => p.SecEntityOwnedRelZeroOrManies).LoadAsync(cancellationToken);
		var ownedId = TestWebApp.Domain.SecEntityOwnedRelZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.SecEntityOwnedRelZeroOrManies.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrMany.SecEntityOwnedRelZeroOrManies", $"{ownedId.ToString()}");
		}

		_entityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		_dbContext.Entry(entity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}

		return new SecEntityOwnedRelZeroOrManyKeyDto(entity.Id.Value);
	}
}