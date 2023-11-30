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
using TestEntityZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrOneCommand(TestEntityZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrOneKeyDto>;

internal partial class CreateTestEntityZeroOrOneCommandHandler : CreateTestEntityZeroOrOneCommandHandlerBase
{
	public CreateTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> SecondTestEntityZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,SecondTestEntityZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityZeroOrOneCommand,TestEntityZeroOrOneEntity>, IRequestHandler <CreateTestEntityZeroOrOneCommand, TestEntityZeroOrOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> SecondTestEntityZeroOrOneFactory;

	public CreateTestEntityZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> SecondTestEntityZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.SecondTestEntityZeroOrOneFactory = SecondTestEntityZeroOrOneFactory;
	}

	public virtual async Task<TestEntityZeroOrOneKeyDto> Handle(CreateTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.SecondTestEntityZeroOrOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.SecondTestEntityZeroOrOneMetadata.CreateId(request.EntityDto.SecondTestEntityZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.SecondTestEntityZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToSecondTestEntityZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrOne", request.EntityDto.SecondTestEntityZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.SecondTestEntityZeroOrOne is not null)
		{
			var relatedEntity = SecondTestEntityZeroOrOneFactory.CreateEntity(request.EntityDto.SecondTestEntityZeroOrOne);
			entityToCreate.CreateRefToSecondTestEntityZeroOrOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityZeroOrOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}