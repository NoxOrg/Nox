﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityZeroOrOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrOneToZeroOrManyCommand(TestEntityZeroOrOneToZeroOrManyCreateDto EntityDto) : IRequest<TestEntityZeroOrOneToZeroOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrOneToZeroOrManyCommandHandler : CreateTestEntityZeroOrOneToZeroOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrOneToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> testentityzeroormanytozerooronefactory,
		IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityzeroormanytozerooronefactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneToZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityZeroOrOneToZeroOrManyCommand,TestEntityZeroOrOneToZeroOrManyEntity>, IRequestHandler <CreateTestEntityZeroOrOneToZeroOrManyCommand, TestEntityZeroOrOneToZeroOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> _testentityzeroormanytozerooronefactory;

	public CreateTestEntityZeroOrOneToZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> testentityzeroormanytozerooronefactory,
		IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityzeroormanytozerooronefactory = testentityzeroormanytozerooronefactory;
	}

	public virtual async Task<TestEntityZeroOrOneToZeroOrManyKeyDto> Handle(CreateTestEntityZeroOrOneToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityZeroOrManyToZeroOrOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrManyToZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityZeroOrManyToZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrManyToZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToZeroOrOne", request.EntityDto.TestEntityZeroOrManyToZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrManyToZeroOrOne is not null)
		{
			var relatedEntity = _testentityzeroormanytozerooronefactory.CreateEntity(request.EntityDto.TestEntityZeroOrManyToZeroOrOne);
			entityToCreate.CreateRefToTestEntityZeroOrManyToZeroOrOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityZeroOrOneToZeroOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityZeroOrOneToZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}