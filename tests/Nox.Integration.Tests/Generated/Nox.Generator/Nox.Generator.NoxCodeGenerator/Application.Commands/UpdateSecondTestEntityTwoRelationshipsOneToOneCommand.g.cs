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
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public record UpdateSecondTestEntityTwoRelationshipsOneToOneCommand(System.String keyId, SecondTestEntityTwoRelationshipsOneToOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<SecondTestEntityTwoRelationshipsOneToOneKeyDto?>;

internal partial class UpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandler : UpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public UpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<UpdateSecondTestEntityTwoRelationshipsOneToOneCommand, SecondTestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler<UpdateSecondTestEntityTwoRelationshipsOneToOneCommand, SecondTestEntityTwoRelationshipsOneToOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> _entityFactory;

	public UpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToOneKeyDto?> Handle(UpdateSecondTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityTwoRelationshipsOneToOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		if(request.EntityDto.TestRelationshipOneOnOtherSideId is not null)
		{
			var testRelationshipOneOnOtherSideKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>());
			var testRelationshipOneOnOtherSideEntity = await DbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(testRelationshipOneOnOtherSideKey);
						
			if(testRelationshipOneOnOtherSideEntity is not null)
				entity.CreateRefToTestRelationshipOneOnOtherSide(testRelationshipOneOnOtherSideEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOneOnOtherSide", request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else
		{
			entity.DeleteAllRefToTestRelationshipOneOnOtherSide();
		}

		if(request.EntityDto.TestRelationshipTwoOnOtherSideId is not null)
		{
			var testRelationshipTwoOnOtherSideKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>());
			var testRelationshipTwoOnOtherSideEntity = await DbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(testRelationshipTwoOnOtherSideKey);
						
			if(testRelationshipTwoOnOtherSideEntity is not null)
				entity.CreateRefToTestRelationshipTwoOnOtherSide(testRelationshipTwoOnOtherSideEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwoOnOtherSide", request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else
		{
			entity.DeleteAllRefToTestRelationshipTwoOnOtherSide();
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityTwoRelationshipsOneToOneKeyDto(entity.Id.Value);
	}
}