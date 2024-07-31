﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityTwoRelationshipsOneToOneCommand(TestEntityTwoRelationshipsOneToOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityTwoRelationshipsOneToOneKeyDto>;

internal partial class CreateTestEntityTwoRelationshipsOneToOneCommandHandler : CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public CreateTestEntityTwoRelationshipsOneToOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> SecondTestEntityTwoRelationshipsOneToOneFactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(repository, noxSolution,SecondTestEntityTwoRelationshipsOneToOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<CreateTestEntityTwoRelationshipsOneToOneCommand,TestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler <CreateTestEntityTwoRelationshipsOneToOneCommand, TestEntityTwoRelationshipsOneToOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> SecondTestEntityTwoRelationshipsOneToOneFactory;

	protected CreateTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> SecondTestEntityTwoRelationshipsOneToOneFactory,
		IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.SecondTestEntityTwoRelationshipsOneToOneFactory = SecondTestEntityTwoRelationshipsOneToOneFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsOneToOneKeyDto> Handle(CreateTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestRelationshipOneId is not null)
		{
			var relatedKey = Dto.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOne", request.EntityDto.TestRelationshipOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipOne is not null)
		{
			var relatedEntity = await SecondTestEntityTwoRelationshipsOneToOneFactory.CreateEntityAsync(request.EntityDto.TestRelationshipOne, request.CultureCode);
			entityToCreate.CreateRefToTestRelationshipOne(relatedEntity);
		}
		if(request.EntityDto.TestRelationshipTwoId is not null)
		{
			var relatedKey = Dto.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipTwoId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwo", request.EntityDto.TestRelationshipTwoId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipTwo is not null)
		{
			var relatedEntity = await SecondTestEntityTwoRelationshipsOneToOneFactory.CreateEntityAsync(request.EntityDto.TestRelationshipTwo, request.CultureCode);
			entityToCreate.CreateRefToTestRelationshipTwo(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityTwoRelationshipsOneToOneKeyDto(entityToCreate.Id.Value);
	}
}