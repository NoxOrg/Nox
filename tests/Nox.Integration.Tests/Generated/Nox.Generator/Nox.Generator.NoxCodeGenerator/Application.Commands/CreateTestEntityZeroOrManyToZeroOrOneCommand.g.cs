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
using TestEntityZeroOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrManyToZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrManyToZeroOrOneKeyDto>;

internal partial class CreateTestEntityZeroOrManyToZeroOrOneCommandHandler : CreateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase
{
	public CreateTestEntityZeroOrManyToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> TestEntityZeroOrOneToZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityZeroOrOneToZeroOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityZeroOrManyToZeroOrOneCommand,TestEntityZeroOrManyToZeroOrOneEntity>, IRequestHandler <CreateTestEntityZeroOrManyToZeroOrOneCommand, TestEntityZeroOrManyToZeroOrOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> TestEntityZeroOrOneToZeroOrManyFactory;

	protected CreateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> TestEntityZeroOrOneToZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrOneToZeroOrManyFactory = TestEntityZeroOrOneToZeroOrManyFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToZeroOrOneKeyDto> Handle(CreateTestEntityZeroOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityZeroOrOneToZeroOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestEntityZeroOrOneToZeroOrManiesId)
			{
				var relatedKey = Dto.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<TestEntityZeroOrOneToZeroOrMany>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestEntityZeroOrOneToZeroOrManies(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToZeroOrManies", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestEntityZeroOrOneToZeroOrManies)
			{
				var relatedEntity = await TestEntityZeroOrOneToZeroOrManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestEntityZeroOrOneToZeroOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityZeroOrManyToZeroOrOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityZeroOrManyToZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}