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
using TestEntityExactlyOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityExactlyOneToZeroOrManyCommand(TestEntityExactlyOneToZeroOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityExactlyOneToZeroOrManyKeyDto>;

internal partial class CreateTestEntityExactlyOneToZeroOrManyCommandHandler : CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase
{
	public CreateTestEntityExactlyOneToZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> TestEntityZeroOrManyToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityZeroOrManyToExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneToZeroOrManyCommand,TestEntityExactlyOneToZeroOrManyEntity>, IRequestHandler <CreateTestEntityExactlyOneToZeroOrManyCommand, TestEntityExactlyOneToZeroOrManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> TestEntityZeroOrManyToExactlyOneFactory;

	protected CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> TestEntityZeroOrManyToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrManyToExactlyOneFactory = TestEntityZeroOrManyToExactlyOneFactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrManyKeyDto> Handle(CreateTestEntityExactlyOneToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);
		if(request.EntityDto.TestEntityZeroOrManyToExactlyOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrManyToExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityZeroOrManyToExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToExactlyOne", request.EntityDto.TestEntityZeroOrManyToExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrManyToExactlyOne is not null)
		{
			var relatedEntity = await TestEntityZeroOrManyToExactlyOneFactory.CreateEntityAsync(request.EntityDto.TestEntityZeroOrManyToExactlyOne);
			entityToCreate.CreateRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityExactlyOneToZeroOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}