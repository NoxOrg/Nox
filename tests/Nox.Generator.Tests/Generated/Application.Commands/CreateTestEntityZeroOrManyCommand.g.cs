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
using TestEntityZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrManyCommand(TestEntityZeroOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrManyCommandHandler : CreateTestEntityZeroOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> SecondTestEntityZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,SecondTestEntityZeroOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityZeroOrManyCommand,TestEntityZeroOrManyEntity>, IRequestHandler <CreateTestEntityZeroOrManyCommand, TestEntityZeroOrManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> SecondTestEntityZeroOrManyFactory;

	public CreateTestEntityZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrMany, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> SecondTestEntityZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyEntity, TestEntityZeroOrManyCreateDto, TestEntityZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.SecondTestEntityZeroOrManyFactory = SecondTestEntityZeroOrManyFactory;
	}

	public virtual async Task<TestEntityZeroOrManyKeyDto> Handle(CreateTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.SecondTestEntityZeroOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.SecondTestEntityZeroOrManiesId)
			{
				var relatedKey = TestWebApp.Domain.SecondTestEntityZeroOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.SecondTestEntityZeroOrManies.FindAsync(relatedKey);

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
				var relatedEntity = SecondTestEntityZeroOrManyFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToSecondTestEntityZeroOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityZeroOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}