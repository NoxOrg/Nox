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
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityOneOrManyToZeroOrManyCommand(TestEntityOneOrManyToZeroOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityOneOrManyToZeroOrManyKeyDto>;

internal partial class CreateTestEntityOneOrManyToZeroOrManyCommandHandler : CreateTestEntityOneOrManyToZeroOrManyCommandHandlerBase
{
	public CreateTestEntityOneOrManyToZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> TestEntityZeroOrManyToOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityZeroOrManyToOneOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOneOrManyToZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityOneOrManyToZeroOrManyCommand,TestEntityOneOrManyToZeroOrManyEntity>, IRequestHandler <CreateTestEntityOneOrManyToZeroOrManyCommand, TestEntityOneOrManyToZeroOrManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> TestEntityZeroOrManyToOneOrManyFactory;

	protected CreateTestEntityOneOrManyToZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> TestEntityZeroOrManyToOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrManyToOneOrManyFactory = TestEntityZeroOrManyToOneOrManyFactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrManyKeyDto> Handle(CreateTestEntityOneOrManyToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityZeroOrManyToOneOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestEntityZeroOrManyToOneOrManiesId)
			{
				var relatedKey = Dto.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestEntityZeroOrManyToOneOrManies(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToOneOrManies", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestEntityZeroOrManyToOneOrManies)
			{
				var relatedEntity = await TestEntityZeroOrManyToOneOrManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestEntityZeroOrManyToOneOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityOneOrManyToZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}