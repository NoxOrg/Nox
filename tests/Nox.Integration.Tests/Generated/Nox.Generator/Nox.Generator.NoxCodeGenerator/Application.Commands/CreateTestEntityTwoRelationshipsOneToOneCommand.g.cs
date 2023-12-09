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
using FluentValidation;
using Microsoft.Extensions.Logging;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityTwoRelationshipsOneToOneCommand(TestEntityTwoRelationshipsOneToOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityTwoRelationshipsOneToOneKeyDto>;

internal partial class CreateTestEntityTwoRelationshipsOneToOneCommandHandler : CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public CreateTestEntityTwoRelationshipsOneToOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> SecondTestEntityTwoRelationshipsOneToOneFactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,SecondTestEntityTwoRelationshipsOneToOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<CreateTestEntityTwoRelationshipsOneToOneCommand,TestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler <CreateTestEntityTwoRelationshipsOneToOneCommand, TestEntityTwoRelationshipsOneToOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> SecondTestEntityTwoRelationshipsOneToOneFactory;

	protected CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> SecondTestEntityTwoRelationshipsOneToOneFactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.SecondTestEntityTwoRelationshipsOneToOneFactory = SecondTestEntityTwoRelationshipsOneToOneFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToOneKeyDto> Handle(CreateTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);
		if(request.EntityDto.TestRelationshipOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipOneId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsOneToOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOne", request.EntityDto.TestRelationshipOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipOne is not null)
		{
			var relatedEntity = await SecondTestEntityTwoRelationshipsOneToOneFactory.CreateEntityAsync(request.EntityDto.TestRelationshipOne);
			entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
		}
		if(request.EntityDto.TestRelationshipTwoId is not null)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipTwoId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsOneToOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwo", request.EntityDto.TestRelationshipTwoId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipTwo is not null)
		{
			var relatedEntity = await SecondTestEntityTwoRelationshipsOneToOneFactory.CreateEntityAsync(request.EntityDto.TestRelationshipTwo);
			entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityTwoRelationshipsOneToOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityTwoRelationshipsOneToOneKeyDto(entityToCreate.Id.Value);
	}
}