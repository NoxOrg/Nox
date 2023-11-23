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
using SecondTestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Commands;
public partial record PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(TestEntityOwnedRelationshipZeroOrOneKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipZeroOrOneKeyDto?>;

internal partial class PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommandHandler: PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase
{
	public PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase: CommandBase<PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand, SecondTestEntityOwnedRelationshipZeroOrOneEntity>, IRequestHandler <PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand, SecondTestEntityOwnedRelationshipZeroOrOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> EntityFactory { get; }

	public PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipZeroOrOneKeyDto?> Handle(PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.TestEntityOwnedRelationshipZeroOrOnes.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await DbContext.Entry(parentEntity).Reference(e => e.SecondTestEntityOwnedRelationshipZeroOrOne).LoadAsync(cancellationToken);
		var entity = parentEntity.SecondTestEntityOwnedRelationshipZeroOrOne;
		
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

		return new SecondTestEntityOwnedRelationshipZeroOrOneKeyDto();
	}
}