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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityTwoRelationshipsOneToManyCommand(SecondTestEntityTwoRelationshipsOneToManyCreateDto EntityDto) : IRequest<SecondTestEntityTwoRelationshipsOneToManyKeyDto>;

internal partial class CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandler : CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> testentitytworelationshipsonetomanyfactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentitytworelationshipsonetomanyfactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<CreateSecondTestEntityTwoRelationshipsOneToManyCommand,SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler <CreateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> _testentitytworelationshipsonetomanyfactory;

	public CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> testentitytworelationshipsonetomanyfactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentitytworelationshipsonetomanyfactory = testentitytworelationshipsonetomanyfactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToManyKeyDto> Handle(CreateSecondTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestRelationshipOneOnOtherSideId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOneOnOtherSide", request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipOneOnOtherSide is not null)
		{
			var relatedEntity = _testentitytworelationshipsonetomanyfactory.CreateEntity(request.EntityDto.TestRelationshipOneOnOtherSide);
			entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
		}
		if(request.EntityDto.TestRelationshipTwoOnOtherSideId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwoOnOtherSide", request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipTwoOnOtherSide is not null)
		{
			var relatedEntity = _testentitytworelationshipsonetomanyfactory.CreateEntity(request.EntityDto.TestRelationshipTwoOnOtherSide);
			entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.SecondTestEntityTwoRelationshipsOneToManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsOneToManyKeyDto(entityToCreate.Id.Value);
	}
}