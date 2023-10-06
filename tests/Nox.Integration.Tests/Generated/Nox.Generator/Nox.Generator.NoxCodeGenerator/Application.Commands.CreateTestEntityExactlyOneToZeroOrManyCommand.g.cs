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
using TestEntityExactlyOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityExactlyOneToZeroOrManyCommand(TestEntityExactlyOneToZeroOrManyCreateDto EntityDto) : IRequest<TestEntityExactlyOneToZeroOrManyKeyDto>;

internal partial class CreateTestEntityExactlyOneToZeroOrManyCommandHandler : CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase
{
	public CreateTestEntityExactlyOneToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> testentityzeroormanytoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityzeroormanytoexactlyonefactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneToZeroOrManyCommand,TestEntityExactlyOneToZeroOrManyEntity>, IRequestHandler <CreateTestEntityExactlyOneToZeroOrManyCommand, TestEntityExactlyOneToZeroOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> _testentityzeroormanytoexactlyonefactory;

	public CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> testentityzeroormanytoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityzeroormanytoexactlyonefactory = testentityzeroormanytoexactlyonefactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrManyKeyDto> Handle(CreateTestEntityExactlyOneToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityZeroOrManyToExactlyOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrManyToExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityZeroOrManyToExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToExactlyOne", request.EntityDto.TestEntityZeroOrManyToExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrManyToExactlyOne is not null)
		{
			var relatedEntity = _testentityzeroormanytoexactlyonefactory.CreateEntity(request.EntityDto.TestEntityZeroOrManyToExactlyOne);
			entityToCreate.CreateRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityExactlyOneToZeroOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}