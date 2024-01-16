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
using Dto = TestWebApp.Application.Dto;
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrOneToExactlyOneCommand(TestEntityZeroOrOneToExactlyOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrOneToExactlyOneKeyDto>;

internal partial class CreateTestEntityZeroOrOneToExactlyOneCommandHandler : CreateTestEntityZeroOrOneToExactlyOneCommandHandlerBase
{
	public CreateTestEntityZeroOrOneToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> TestEntityExactlyOneToZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityExactlyOneToZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneToExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityZeroOrOneToExactlyOneCommand,TestEntityZeroOrOneToExactlyOneEntity>, IRequestHandler <CreateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> TestEntityExactlyOneToZeroOrOneFactory;

	protected CreateTestEntityZeroOrOneToExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> TestEntityExactlyOneToZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityExactlyOneToZeroOrOneFactory = TestEntityExactlyOneToZeroOrOneFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToExactlyOneKeyDto> Handle(CreateTestEntityZeroOrOneToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityExactlyOneToZeroOrOneId is not null)
		{
			var relatedKey = Dto.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityExactlyOneToZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityExactlyOneToZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityExactlyOneToZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrOne", request.EntityDto.TestEntityExactlyOneToZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityExactlyOneToZeroOrOne is not null)
		{
			var relatedEntity = await TestEntityExactlyOneToZeroOrOneFactory.CreateEntityAsync(request.EntityDto.TestEntityExactlyOneToZeroOrOne, request.CultureCode);
			entityToCreate.CreateRefToTestEntityExactlyOneToZeroOrOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityZeroOrOneToExactlyOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrOneToExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}