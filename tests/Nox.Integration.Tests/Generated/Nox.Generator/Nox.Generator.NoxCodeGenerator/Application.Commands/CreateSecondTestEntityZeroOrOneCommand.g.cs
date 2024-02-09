﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecondTestEntityZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record CreateSecondTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<SecondTestEntityZeroOrOneKeyDto>;

internal partial class CreateSecondTestEntityZeroOrOneCommandHandler : CreateSecondTestEntityZeroOrOneCommandHandlerBase
{
	public CreateSecondTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOne, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> TestEntityZeroOrOneFactory,
		IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityZeroOrOneCommandHandlerBase : CommandBase<CreateSecondTestEntityZeroOrOneCommand,SecondTestEntityZeroOrOneEntity>, IRequestHandler <CreateSecondTestEntityZeroOrOneCommand, SecondTestEntityZeroOrOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOne, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> TestEntityZeroOrOneFactory;

	protected CreateSecondTestEntityZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOne, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> TestEntityZeroOrOneFactory,
		IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrOneFactory = TestEntityZeroOrOneFactory;
	}

	public virtual async Task<SecondTestEntityZeroOrOneKeyDto> Handle(CreateSecondTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityZeroOrOneId is not null)
		{
			var relatedKey = Dto.TestEntityZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestWebApp.Domain.TestEntityZeroOrOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOne", request.EntityDto.TestEntityZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrOne is not null)
		{
			var relatedEntity = await TestEntityZeroOrOneFactory.CreateEntityAsync(request.EntityDto.TestEntityZeroOrOne, request.CultureCode);
			entityToCreate.CreateRefToTestEntityZeroOrOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestWebApp.Domain.SecondTestEntityZeroOrOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new SecondTestEntityZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}