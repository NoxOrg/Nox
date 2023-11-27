
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
public partial record PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipExactlyOneKeyDto?>;

internal partial class PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler: PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipExactlyOneEntity, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase: CommandBase<PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecondTestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler <PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecondTestEntityOwnedRelationshipExactlyOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityOwnedRelationshipExactlyOneEntity, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> EntityFactory { get; }

	public PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipExactlyOneEntity, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipExactlyOneKeyDto?> Handle(PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await DbContext.Entry(parentEntity).Reference(e => e.SecondTestEntityOwnedRelationshipExactlyOne).LoadAsync(cancellationToken);
		var entity = parentEntity.SecondTestEntityOwnedRelationshipExactlyOne;
		
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, DefaultCultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOwnedRelationshipExactlyOneKeyDto();
	}
}