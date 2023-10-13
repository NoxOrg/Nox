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
using Nox.Application.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityExactlyOneToOneOrManyCommand(TestEntityExactlyOneToOneOrManyCreateDto EntityDto) : IRequest<TestEntityExactlyOneToOneOrManyKeyDto>;

internal partial class CreateTestEntityExactlyOneToOneOrManyCommandHandler : CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase
{
	public CreateTestEntityExactlyOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> testentityoneormanytoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,testentityoneormanytoexactlyonefactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneToOneOrManyCommand,TestEntityExactlyOneToOneOrManyEntity>, IRequestHandler <CreateTestEntityExactlyOneToOneOrManyCommand, TestEntityExactlyOneToOneOrManyKeyDto>
{
	private readonly TestWebAppDbContext _dbContext;
	private readonly IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> _entityFactory;
	private readonly IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> _testentityoneormanytoexactlyonefactory;

	public CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> testentityoneormanytoexactlyonefactory,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_testentityoneormanytoexactlyonefactory = testentityoneormanytoexactlyonefactory;
	}

	public virtual async Task<TestEntityExactlyOneToOneOrManyKeyDto> Handle(CreateTestEntityExactlyOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityOneOrManyToExactlyOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateId(request.EntityDto.TestEntityOneOrManyToExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.TestEntityOneOrManyToExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityOneOrManyToExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityOneOrManyToExactlyOne", request.EntityDto.TestEntityOneOrManyToExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityOneOrManyToExactlyOne is not null)
		{
			var relatedEntity = _testentityoneormanytoexactlyonefactory.CreateEntity(request.EntityDto.TestEntityOneOrManyToExactlyOne);
			entityToCreate.CreateRefToTestEntityOneOrManyToExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.TestEntityExactlyOneToOneOrManies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}