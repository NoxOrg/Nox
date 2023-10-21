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
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateSecondTestEntityExactlyOneCommand(SecondTestEntityExactlyOneCreateDto EntityDto) : IRequest<SecondTestEntityExactlyOneKeyDto>;

internal partial class CreateSecondTestEntityExactlyOneCommandHandler : CreateSecondTestEntityExactlyOneCommandHandlerBase
{
	public CreateSecondTestEntityExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> TestEntityExactlyOneFactory,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityExactlyOneCommandHandlerBase : CommandBase<CreateSecondTestEntityExactlyOneCommand,SecondTestEntityExactlyOneEntity>, IRequestHandler <CreateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneKeyDto>
{
	protected readonly TestWebAppDbContext DbContext;
	protected readonly IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> TestEntityExactlyOneFactory;

	public CreateSecondTestEntityExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> TestEntityExactlyOneFactory,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityExactlyOneFactory = TestEntityExactlyOneFactory;
	}

	public virtual async Task<SecondTestEntityExactlyOneKeyDto> Handle(CreateSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityExactlyOneRelationshipId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityExactlyOneMetadata.CreateId(request.EntityDto.TestEntityExactlyOneRelationshipId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityExactlyOneRelationship(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityExactlyOneRelationship", request.EntityDto.TestEntityExactlyOneRelationshipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityExactlyOneRelationship is not null)
		{
			var relatedEntity = TestEntityExactlyOneFactory.CreateEntity(request.EntityDto.TestEntityExactlyOneRelationship);
			entityToCreate.CreateRefToTestEntityExactlyOneRelationship(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.SecondTestEntityExactlyOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new SecondTestEntityExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}