﻿﻿// Generated

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
using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityOneOrManyCommand(TestEntityOneOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityOneOrManyKeyDto>;

internal partial class CreateTestEntityOneOrManyCommandHandler : CreateTestEntityOneOrManyCommandHandlerBase
{
	public CreateTestEntityOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> SecondTestEntityOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution,SecondTestEntityOneOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityOneOrManyCommand,TestEntityOneOrManyEntity>, IRequestHandler <CreateTestEntityOneOrManyCommand, TestEntityOneOrManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> SecondTestEntityOneOrManyFactory;

	protected CreateTestEntityOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> SecondTestEntityOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.SecondTestEntityOneOrManyFactory = SecondTestEntityOneOrManyFactory;
	}

	public virtual async Task<TestEntityOneOrManyKeyDto> Handle(CreateTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.SecondTestEntityOneOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.SecondTestEntityOneOrManiesId)
			{
				var relatedKey = Dto.SecondTestEntityOneOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<TestWebApp.Domain.SecondTestEntityOneOrMany>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToSecondTestEntityOneOrManies(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("SecondTestEntityOneOrManies", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.SecondTestEntityOneOrManies)
			{
				var relatedEntity = await SecondTestEntityOneOrManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToSecondTestEntityOneOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestWebApp.Domain.TestEntityOneOrMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}