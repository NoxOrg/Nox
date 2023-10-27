﻿// Generated

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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public record UpdateSecondTestEntityTwoRelationshipsOneToManyCommand(System.String keyId, SecondTestEntityTwoRelationshipsOneToManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<SecondTestEntityTwoRelationshipsOneToManyKeyDto?>;

internal partial class UpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandler : UpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public UpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<UpdateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> _entityFactory;

	public UpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToManyKeyDto?> Handle(UpdateSecondTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		if(request.EntityDto.TestRelationshipOneOnOtherSideId is not null)
		{
			var testRelationshipOneOnOtherSideKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>());
			var testRelationshipOneOnOtherSideEntity = await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(testRelationshipOneOnOtherSideKey);
						
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
			var testRelationshipTwoOnOtherSideKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>());
			var testRelationshipTwoOnOtherSideEntity = await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(testRelationshipTwoOnOtherSideKey);
						
			if(testRelationshipTwoOnOtherSideEntity is not null)
				entity.CreateRefToTestRelationshipTwoOnOtherSide(testRelationshipTwoOnOtherSideEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwoOnOtherSide", request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else
		{
			entity.DeleteAllRefToTestRelationshipTwoOnOtherSide();
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityTwoRelationshipsOneToManyKeyDto(entity.Id.Value);
	}
}