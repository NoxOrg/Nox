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

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityOneOrManyCommand(TestEntityOneOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityOneOrManyKeyDto>;

internal partial class CreateTestEntityOneOrManyCommandHandler : CreateTestEntityOneOrManyCommandHandlerBase
{
	public CreateTestEntityOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> SecondTestEntityOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,SecondTestEntityOneOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityOneOrManyCommand,TestEntityOneOrManyEntity>, IRequestHandler <CreateTestEntityOneOrManyCommand, TestEntityOneOrManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> SecondTestEntityOneOrManyFactory;

	public CreateTestEntityOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityOneOrMany, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> SecondTestEntityOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.SecondTestEntityOneOrManyFactory = SecondTestEntityOneOrManyFactory;
	}

	public virtual async Task<TestEntityOneOrManyKeyDto> Handle(CreateTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.SecondTestEntityOneOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.SecondTestEntityOneOrManiesId)
			{
				var relatedKey = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.SecondTestEntityOneOrManies.FindAsync(relatedKey);

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
				var relatedEntity = SecondTestEntityOneOrManyFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToSecondTestEntityOneOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityOneOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}