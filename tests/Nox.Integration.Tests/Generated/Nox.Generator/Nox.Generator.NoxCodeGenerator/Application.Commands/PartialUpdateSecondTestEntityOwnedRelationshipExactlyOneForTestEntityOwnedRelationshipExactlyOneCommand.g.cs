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
using SecondTestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;
public partial record PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipExactlyOneKeyDto?>;

internal partial class PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler: PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipExactlyOneEntity, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase: CommandBase<PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecondTestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler <PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecondTestEntityOwnedRelationshipExactlyOneKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityOwnedRelationshipExactlyOneEntity, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> _entityFactory;

	protected PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
		AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipExactlyOneEntity, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipExactlyOneKeyDto?> Handle(PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await _dbContext.Entry(parentEntity).Reference(e => e.SecondTestEntityOwnedRelationshipExactlyOne).LoadAsync(cancellationToken);
		var entity = parentEntity.SecondTestEntityOwnedRelationshipExactlyOne;
		
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

		return new SecondTestEntityOwnedRelationshipExactlyOneKeyDto();
	}
}