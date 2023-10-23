﻿﻿// Generated

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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateTestEntityZeroOrOneToOneOrManyCommand(TestEntityZeroOrOneToOneOrManyCreateDto EntityDto) : IRequest<TestEntityZeroOrOneToOneOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrOneToOneOrManyCommandHandler : CreateTestEntityZeroOrOneToOneOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> TestEntityOneOrManyToZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityOneOrManyToZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneToOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityZeroOrOneToOneOrManyCommand,TestEntityZeroOrOneToOneOrManyEntity>, IRequestHandler <CreateTestEntityZeroOrOneToOneOrManyCommand, TestEntityZeroOrOneToOneOrManyKeyDto>
{
	protected readonly TestWebAppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> TestEntityOneOrManyToZeroOrOneFactory;

	public CreateTestEntityZeroOrOneToOneOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> TestEntityOneOrManyToZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityOneOrManyToZeroOrOneFactory = TestEntityOneOrManyToZeroOrOneFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToOneOrManyKeyDto> Handle(CreateTestEntityZeroOrOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityOneOrManyToZeroOrOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityOneOrManyToZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityOneOrManyToZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrOne", request.EntityDto.TestEntityOneOrManyToZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityOneOrManyToZeroOrOne is not null)
		{
			var relatedEntity = TestEntityOneOrManyToZeroOrOneFactory.CreateEntity(request.EntityDto.TestEntityOneOrManyToZeroOrOne);
			entityToCreate.CreateRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityZeroOrOneToOneOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrOneToOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}