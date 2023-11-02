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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityOneOrManyToExactlyOneCommand(TestEntityOneOrManyToExactlyOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityOneOrManyToExactlyOneKeyDto>;

internal partial class CreateTestEntityOneOrManyToExactlyOneCommandHandler : CreateTestEntityOneOrManyToExactlyOneCommandHandlerBase
{
	public CreateTestEntityOneOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> TestEntityExactlyOneToOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityExactlyOneToOneOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOneOrManyToExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityOneOrManyToExactlyOneCommand,TestEntityOneOrManyToExactlyOneEntity>, IRequestHandler <CreateTestEntityOneOrManyToExactlyOneCommand, TestEntityOneOrManyToExactlyOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> TestEntityExactlyOneToOneOrManyFactory;

	public CreateTestEntityOneOrManyToExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> TestEntityExactlyOneToOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityExactlyOneToOneOrManyFactory = TestEntityExactlyOneToOneOrManyFactory;
	}

	public virtual async Task<TestEntityOneOrManyToExactlyOneKeyDto> Handle(CreateTestEntityOneOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityExactlyOneToOneOrManyId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestEntityExactlyOneToOneOrManyId)
			{
				var relatedKey = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.TestEntityExactlyOneToOneOrManies.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestEntityExactlyOneToOneOrMany(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestEntityExactlyOneToOneOrMany", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestEntityExactlyOneToOneOrMany)
			{
				var relatedEntity = TestEntityExactlyOneToOneOrManyFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToTestEntityExactlyOneToOneOrMany(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityOneOrManyToExactlyOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityOneOrManyToExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}