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
using Dto = TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record CreateSecondTestEntityTwoRelationshipsManyToManyCommand(SecondTestEntityTwoRelationshipsManyToManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<SecondTestEntityTwoRelationshipsManyToManyKeyDto>;

internal partial class CreateSecondTestEntityTwoRelationshipsManyToManyCommandHandler : CreateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public CreateSecondTestEntityTwoRelationshipsManyToManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> TestEntityTwoRelationshipsManyToManyFactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityTwoRelationshipsManyToManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<CreateSecondTestEntityTwoRelationshipsManyToManyCommand,SecondTestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler <CreateSecondTestEntityTwoRelationshipsManyToManyCommand, SecondTestEntityTwoRelationshipsManyToManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> TestEntityTwoRelationshipsManyToManyFactory;

	protected CreateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> TestEntityTwoRelationshipsManyToManyFactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityTwoRelationshipsManyToManyFactory = TestEntityTwoRelationshipsManyToManyFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsManyToManyKeyDto> Handle(CreateSecondTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestRelationshipOneOnOtherSideId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestRelationshipOneOnOtherSideId)
			{
				var relatedKey = Dto.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestRelationshipOneOnOtherSide", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestRelationshipOneOnOtherSide)
			{
				var relatedEntity = await TestEntityTwoRelationshipsManyToManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
			}
		}
		if(request.EntityDto.TestRelationshipTwoOnOtherSideId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestRelationshipTwoOnOtherSideId)
			{
				var relatedKey = Dto.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestRelationshipTwoOnOtherSide", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestRelationshipTwoOnOtherSide)
			{
				var relatedEntity = await TestEntityTwoRelationshipsManyToManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.SecondTestEntityTwoRelationshipsManyToManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsManyToManyKeyDto(entityToCreate.Id.Value);
	}
}