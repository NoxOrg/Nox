﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public partial record CreateSecondTestEntityTwoRelationshipsOneToOneCommand(SecondTestEntityTwoRelationshipsOneToOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<SecondTestEntityTwoRelationshipsOneToOneKeyDto>;

internal partial class CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandler : CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> TestEntityTwoRelationshipsOneToOneFactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityTwoRelationshipsOneToOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<CreateSecondTestEntityTwoRelationshipsOneToOneCommand,SecondTestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler <CreateSecondTestEntityTwoRelationshipsOneToOneCommand, SecondTestEntityTwoRelationshipsOneToOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> TestEntityTwoRelationshipsOneToOneFactory;

	public CreateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto> TestEntityTwoRelationshipsOneToOneFactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityTwoRelationshipsOneToOneFactory = TestEntityTwoRelationshipsOneToOneFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToOneKeyDto> Handle(CreateSecondTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestRelationshipOneOnOtherSideId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOneOnOtherSide", request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipOneOnOtherSide is not null)
		{
			var relatedEntity = TestEntityTwoRelationshipsOneToOneFactory.CreateEntity(request.EntityDto.TestRelationshipOneOnOtherSide);
			entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
		}
		if(request.EntityDto.TestRelationshipTwoOnOtherSideId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwoOnOtherSide", request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipTwoOnOtherSide is not null)
		{
			var relatedEntity = TestEntityTwoRelationshipsOneToOneFactory.CreateEntity(request.EntityDto.TestRelationshipTwoOnOtherSide);
			entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.SecondTestEntityTwoRelationshipsOneToOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsOneToOneKeyDto(entityToCreate.Id.Value);
	}
}