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
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityExactlyOneToOneOrManyCommand(TestEntityExactlyOneToOneOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityExactlyOneToOneOrManyKeyDto>;

internal partial class CreateTestEntityExactlyOneToOneOrManyCommandHandler : CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase
{
	public CreateTestEntityExactlyOneToOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> TestEntityOneOrManyToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityOneOrManyToExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneToOneOrManyCommand,TestEntityExactlyOneToOneOrManyEntity>, IRequestHandler <CreateTestEntityExactlyOneToOneOrManyCommand, TestEntityExactlyOneToOneOrManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> TestEntityOneOrManyToExactlyOneFactory;

	protected CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> TestEntityOneOrManyToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityOneOrManyToExactlyOneFactory = TestEntityOneOrManyToExactlyOneFactory;
	}

	public virtual async Task<TestEntityExactlyOneToOneOrManyKeyDto> Handle(CreateTestEntityExactlyOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityOneOrManyToExactlyOneId is not null)
		{
			var relatedKey = Dto.TestEntityOneOrManyToExactlyOneMetadata.CreateId(request.EntityDto.TestEntityOneOrManyToExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestEntityOneOrManyToExactlyOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityOneOrManyToExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityOneOrManyToExactlyOne", request.EntityDto.TestEntityOneOrManyToExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityOneOrManyToExactlyOne is not null)
		{
			var relatedEntity = await TestEntityOneOrManyToExactlyOneFactory.CreateEntityAsync(request.EntityDto.TestEntityOneOrManyToExactlyOne, request.CultureCode);
			entityToCreate.CreateRefToTestEntityOneOrManyToExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityExactlyOneToOneOrMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityExactlyOneToOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}