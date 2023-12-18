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
using TestEntityZeroOrOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrOneToZeroOrManyCommand(TestEntityZeroOrOneToZeroOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrOneToZeroOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrOneToZeroOrManyCommandHandler : CreateTestEntityZeroOrOneToZeroOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrOneToZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> TestEntityZeroOrManyToZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityZeroOrManyToZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneToZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityZeroOrOneToZeroOrManyCommand,TestEntityZeroOrOneToZeroOrManyEntity>, IRequestHandler <CreateTestEntityZeroOrOneToZeroOrManyCommand, TestEntityZeroOrOneToZeroOrManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> TestEntityZeroOrManyToZeroOrOneFactory;

	protected CreateTestEntityZeroOrOneToZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> TestEntityZeroOrManyToZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrManyToZeroOrOneFactory = TestEntityZeroOrManyToZeroOrOneFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToZeroOrManyKeyDto> Handle(CreateTestEntityZeroOrOneToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityZeroOrManyToZeroOrOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrManyToZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityZeroOrManyToZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrManyToZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToZeroOrOne", request.EntityDto.TestEntityZeroOrManyToZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrManyToZeroOrOne is not null)
		{
			var relatedEntity = await TestEntityZeroOrManyToZeroOrOneFactory.CreateEntityAsync(request.EntityDto.TestEntityZeroOrManyToZeroOrOne, request.CultureCode);
			entityToCreate.CreateRefToTestEntityZeroOrManyToZeroOrOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityZeroOrOneToZeroOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrOneToZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}