﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public partial record CreateSecondTestEntityTwoRelationshipsOneToManyCommand(SecondTestEntityTwoRelationshipsOneToManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<SecondTestEntityTwoRelationshipsOneToManyKeyDto>;

internal partial class CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandler : CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> TestEntityTwoRelationshipsOneToManyFactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityTwoRelationshipsOneToManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<CreateSecondTestEntityTwoRelationshipsOneToManyCommand,SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler <CreateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> TestEntityTwoRelationshipsOneToManyFactory;

	protected CreateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto> TestEntityTwoRelationshipsOneToManyFactory,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityTwoRelationshipsOneToManyFactory = TestEntityTwoRelationshipsOneToManyFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToManyKeyDto> Handle(CreateSecondTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestRelationshipOneOnOtherSideId is not null)
		{
			var relatedKey = Dto.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestEntityTwoRelationshipsOneToMany>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipOneOnOtherSide", request.EntityDto.TestRelationshipOneOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipOneOnOtherSide is not null)
		{
			var relatedEntity = await TestEntityTwoRelationshipsOneToManyFactory.CreateEntityAsync(request.EntityDto.TestRelationshipOneOnOtherSide, request.CultureCode);
			entityToCreate.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
		}
		if(request.EntityDto.TestRelationshipTwoOnOtherSideId is not null)
		{
			var relatedKey = Dto.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestEntityTwoRelationshipsOneToMany>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestRelationshipTwoOnOtherSide", request.EntityDto.TestRelationshipTwoOnOtherSideId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestRelationshipTwoOnOtherSide is not null)
		{
			var relatedEntity = await TestEntityTwoRelationshipsOneToManyFactory.CreateEntityAsync(request.EntityDto.TestRelationshipTwoOnOtherSide, request.CultureCode);
			entityToCreate.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<SecondTestEntityTwoRelationshipsOneToMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsOneToManyKeyDto(entityToCreate.Id.Value);
	}
}