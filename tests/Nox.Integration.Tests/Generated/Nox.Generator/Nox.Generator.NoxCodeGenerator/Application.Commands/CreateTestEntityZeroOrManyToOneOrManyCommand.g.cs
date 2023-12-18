﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
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
using TestEntityZeroOrManyToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrManyToOneOrManyCommand(TestEntityZeroOrManyToOneOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrManyToOneOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrManyToOneOrManyCommandHandler : CreateTestEntityZeroOrManyToOneOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrManyToOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> TestEntityOneOrManyToZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityOneOrManyToZeroOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyToOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityZeroOrManyToOneOrManyCommand,TestEntityZeroOrManyToOneOrManyEntity>, IRequestHandler <CreateTestEntityZeroOrManyToOneOrManyCommand, TestEntityZeroOrManyToOneOrManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> TestEntityOneOrManyToZeroOrManyFactory;

	protected CreateTestEntityZeroOrManyToOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> TestEntityOneOrManyToZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityOneOrManyToZeroOrManyFactory = TestEntityOneOrManyToZeroOrManyFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToOneOrManyKeyDto> Handle(CreateTestEntityZeroOrManyToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityOneOrManyToZeroOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestEntityOneOrManyToZeroOrManiesId)
			{
				var relatedKey = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestEntityOneOrManyToZeroOrManies(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrManies", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestEntityOneOrManyToZeroOrManies)
			{
				var relatedEntity = await TestEntityOneOrManyToZeroOrManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTestEntityOneOrManyToZeroOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityZeroOrManyToOneOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyToOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}