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
using TestEntityExactlyOneEntity = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityExactlyOneCommand(TestEntityExactlyOneCreateDto EntityDto) : IRequest<TestEntityExactlyOneKeyDto>;

internal partial class CreateTestEntityExactlyOneCommandHandler : CreateTestEntityExactlyOneCommandHandlerBase
{
	public CreateTestEntityExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> SecondTestEntityExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,SecondTestEntityExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneCommand,TestEntityExactlyOneEntity>, IRequestHandler <CreateTestEntityExactlyOneCommand, TestEntityExactlyOneKeyDto>
{
	protected readonly TestWebAppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> SecondTestEntityExactlyOneFactory;

	public CreateTestEntityExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> SecondTestEntityExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.SecondTestEntityExactlyOneFactory = SecondTestEntityExactlyOneFactory;
	}

	public virtual async Task<TestEntityExactlyOneKeyDto> Handle(CreateTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.SecondTestEntityExactlyOneRelationshipId is not null)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(request.EntityDto.SecondTestEntityExactlyOneRelationshipId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.SecondTestEntityExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToSecondTestEntityExactlyOneRelationship(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("SecondTestEntityExactlyOneRelationship", request.EntityDto.SecondTestEntityExactlyOneRelationshipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.SecondTestEntityExactlyOneRelationship is not null)
		{
			var relatedEntity = SecondTestEntityExactlyOneFactory.CreateEntity(request.EntityDto.SecondTestEntityExactlyOneRelationship);
			entityToCreate.CreateRefToSecondTestEntityExactlyOneRelationship(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityExactlyOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}