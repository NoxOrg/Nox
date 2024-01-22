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

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using TestEntityZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrManyCommand(TestEntityZeroOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrManyCommandHandler : CreateTestEntityZeroOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> SecondTestEntityZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution,SecondTestEntityZeroOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityZeroOrManyCommand,TestEntityZeroOrManyEntity>, IRequestHandler <CreateTestEntityZeroOrManyCommand, TestEntityZeroOrManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> SecondTestEntityZeroOrManyFactory;

	protected CreateTestEntityZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> SecondTestEntityZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.SecondTestEntityZeroOrManyFactory = SecondTestEntityZeroOrManyFactory;
	}

	public virtual async Task<TestEntityZeroOrManyKeyDto> Handle(CreateTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.SecondTestEntityZeroOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.SecondTestEntityZeroOrManiesId)
			{
				var relatedKey = Dto.SecondTestEntityZeroOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<SecondTestEntityZeroOrMany>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToSecondTestEntityZeroOrManies(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrManies", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.SecondTestEntityZeroOrManies)
			{
				var relatedEntity = await SecondTestEntityZeroOrManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToSecondTestEntityZeroOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityZeroOrMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}