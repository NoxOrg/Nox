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
using TestEntityZeroOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrManyToZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrManyToZeroOrOneKeyDto>;

internal partial class CreateTestEntityZeroOrManyToZeroOrOneCommandHandler : CreateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase
{
	public CreateTestEntityZeroOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> TestEntityZeroOrOneToZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityZeroOrOneToZeroOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityZeroOrManyToZeroOrOneCommand,TestEntityZeroOrManyToZeroOrOneEntity>, IRequestHandler <CreateTestEntityZeroOrManyToZeroOrOneCommand, TestEntityZeroOrManyToZeroOrOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> TestEntityZeroOrOneToZeroOrManyFactory;

	public CreateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> TestEntityZeroOrOneToZeroOrManyFactory,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrOneToZeroOrManyFactory = TestEntityZeroOrOneToZeroOrManyFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToZeroOrOneKeyDto> Handle(CreateTestEntityZeroOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityZeroOrOneToZeroOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestEntityZeroOrOneToZeroOrManiesId)
			{
				var relatedKey = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.TestEntityZeroOrOneToZeroOrManies.FindAsync(relatedKey);

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
				var relatedEntity = TestEntityZeroOrOneToZeroOrManyFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToTestEntityZeroOrOneToZeroOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityZeroOrManyToZeroOrOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyToZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}