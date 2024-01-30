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
using TestEntityZeroOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrManyToExactlyOneCommand(TestEntityZeroOrManyToExactlyOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrManyToExactlyOneKeyDto>;

internal partial class CreateTestEntityZeroOrManyToExactlyOneCommandHandler : CreateTestEntityZeroOrManyToExactlyOneCommandHandlerBase
{
	public CreateTestEntityZeroOrManyToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> TestEntityExactlyOneToZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityExactlyOneToZeroOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyToExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityZeroOrManyToExactlyOneCommand,TestEntityZeroOrManyToExactlyOneEntity>, IRequestHandler <CreateTestEntityZeroOrManyToExactlyOneCommand, TestEntityZeroOrManyToExactlyOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> TestEntityExactlyOneToZeroOrManyFactory;

	protected CreateTestEntityZeroOrManyToExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> TestEntityExactlyOneToZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityExactlyOneToZeroOrManyFactory = TestEntityExactlyOneToZeroOrManyFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToExactlyOneKeyDto> Handle(CreateTestEntityZeroOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityExactlyOneToZeroOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestEntityExactlyOneToZeroOrManiesId)
			{
				var relatedKey = Dto.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<TestEntityExactlyOneToZeroOrMany>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestEntityExactlyOneToZeroOrManies(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrManies", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestEntityExactlyOneToZeroOrManies)
			{
				var relatedEntity = await TestEntityExactlyOneToZeroOrManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestEntityExactlyOneToZeroOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityZeroOrManyToExactlyOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityZeroOrManyToExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}