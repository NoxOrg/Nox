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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityOneOrManyToZeroOrOneCommand(TestEntityOneOrManyToZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityOneOrManyToZeroOrOneKeyDto>;

internal partial class CreateTestEntityOneOrManyToZeroOrOneCommandHandler : CreateTestEntityOneOrManyToZeroOrOneCommandHandlerBase
{
	public CreateTestEntityOneOrManyToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> TestEntityZeroOrOneToOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityZeroOrOneToOneOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOneOrManyToZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityOneOrManyToZeroOrOneCommand,TestEntityOneOrManyToZeroOrOneEntity>, IRequestHandler <CreateTestEntityOneOrManyToZeroOrOneCommand, TestEntityOneOrManyToZeroOrOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> TestEntityZeroOrOneToOneOrManyFactory;

	protected CreateTestEntityOneOrManyToZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> TestEntityZeroOrOneToOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrOneToOneOrManyFactory = TestEntityZeroOrOneToOneOrManyFactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrOneKeyDto> Handle(CreateTestEntityOneOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityZeroOrOneToOneOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestEntityZeroOrOneToOneOrManiesId)
			{
				var relatedKey = Dto.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestEntityZeroOrOneToOneOrManies(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToOneOrManies", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestEntityZeroOrOneToOneOrManies)
			{
				var relatedEntity = await TestEntityZeroOrOneToOneOrManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestEntityZeroOrOneToOneOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityOneOrManyToZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}