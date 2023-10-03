﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsOneToOne = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityTwoRelationshipsOneToOneCommand(SecondTestEntityTwoRelationshipsOneToOneCreateDto EntityDto) : IRequest<SecondTestEntityTwoRelationshipsOneToOneKeyDto>;

internal partial class CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandler: CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> testentitytworelationshipsonetoonefactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,testentitytworelationshipsonetoonefactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase: CommandBase<CreateSecondTestEntityTwoRelationshipsOneToOneCommand,SecondTestEntityTwoRelationshipsOneToOne>, IRequestHandler <CreateSecondTestEntityTwoRelationshipsOneToOneCommand, SecondTestEntityTwoRelationshipsOneToOneKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> _testentitytworelationshipsonetoonefactory;

	public CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> testentitytworelationshipsonetoonefactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
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
		if(request.EntityDto.TestRelationshipOneOnOtherSide is not null)
		{
			var relatedEntity = _testentitytworelationshipsonetoonefactory.CreateEntity(request.EntityDto.TestRelationshipOneOnOtherSide);
			entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
		}
		if(request.EntityDto.TestRelationshipTwoOnOtherSide is not null)
		{
			var relatedEntity = _testentitytworelationshipsonetoonefactory.CreateEntity(request.EntityDto.TestRelationshipTwoOnOtherSide);
			entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.SecondTestEntityTwoRelationshipsOneToOnes.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsOneToOneKeyDto(entityToCreate.Id.Value);
	}
}