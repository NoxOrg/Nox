﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityTwoRelationshipsOneToOneCommand(SecondTestEntityTwoRelationshipsOneToOneCreateDto EntityDto) : IRequest<SecondTestEntityTwoRelationshipsOneToOneKeyDto>;

internal partial class CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandler : CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> testentitytworelationshipsonetoonefactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentitytworelationshipsonetoonefactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<CreateSecondTestEntityTwoRelationshipsOneToOneCommand,SecondTestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler <CreateSecondTestEntityTwoRelationshipsOneToOneCommand, SecondTestEntityTwoRelationshipsOneToOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> _testentitytworelationshipsonetoonefactory;

	public CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> testentitytworelationshipsonetoonefactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentitytworelationshipsonetoonefactory = testentitytworelationshipsonetoonefactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToOneKeyDto> Handle(CreateSecondTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestRelationshipOneOnOtherSideId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOneOnOtherSide", request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipOneOnOtherSide is not null)
		{
			var relatedEntity = _testentitytworelationshipsonetoonefactory.CreateEntity(request.EntityDto.TestRelationshipOneOnOtherSide);
			entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
		}
		if(request.EntityDto.TestRelationshipTwoOnOtherSideId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwoOnOtherSide", request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipTwoOnOtherSide is not null)
		{
			var relatedEntity = _testentitytworelationshipsonetoonefactory.CreateEntity(request.EntityDto.TestRelationshipTwoOnOtherSide);
			entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.SecondTestEntityTwoRelationshipsOneToOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsOneToOneKeyDto(entityToCreate.Id.Value);
	}
}