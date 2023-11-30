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
using SecondTestEntityZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record CreateSecondTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<SecondTestEntityZeroOrOneKeyDto>;

internal partial class CreateSecondTestEntityZeroOrOneCommandHandler : CreateSecondTestEntityZeroOrOneCommandHandlerBase
{
	public CreateSecondTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOne, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> TestEntityZeroOrOneFactory,
		IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityZeroOrOneCommandHandlerBase : CommandBase<CreateSecondTestEntityZeroOrOneCommand,SecondTestEntityZeroOrOneEntity>, IRequestHandler <CreateSecondTestEntityZeroOrOneCommand, SecondTestEntityZeroOrOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOne, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> TestEntityZeroOrOneFactory;

	public CreateSecondTestEntityZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOne, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> TestEntityZeroOrOneFactory,
		IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrOneFactory = TestEntityZeroOrOneFactory;
	}

	public virtual async Task<SecondTestEntityZeroOrOneKeyDto> Handle(CreateSecondTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityZeroOrOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOne", request.EntityDto.TestEntityZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrOne is not null)
		{
			var relatedEntity = TestEntityZeroOrOneFactory.CreateEntity(request.EntityDto.TestEntityZeroOrOne);
			entityToCreate.CreateRefToTestEntityZeroOrOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.SecondTestEntityZeroOrOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new SecondTestEntityZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}