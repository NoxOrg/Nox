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

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using TestEntityZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrOneCommand(TestEntityZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrOneKeyDto>;

internal partial class CreateTestEntityZeroOrOneCommandHandler : CreateTestEntityZeroOrOneCommandHandlerBase
{
	public CreateTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> SecondTestEntityZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> entityFactory)
		: base(repository, noxSolution,SecondTestEntityZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityZeroOrOneCommand,TestEntityZeroOrOneEntity>, IRequestHandler <CreateTestEntityZeroOrOneCommand, TestEntityZeroOrOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> SecondTestEntityZeroOrOneFactory;

	protected CreateTestEntityZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> SecondTestEntityZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.SecondTestEntityZeroOrOneFactory = SecondTestEntityZeroOrOneFactory;
	}

	public virtual async Task<TestEntityZeroOrOneKeyDto> Handle(CreateTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.SecondTestEntityZeroOrOneId is not null)
		{
			var relatedKey = Dto.SecondTestEntityZeroOrOneMetadata.CreateId(request.EntityDto.SecondTestEntityZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<SecondTestEntityZeroOrOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToSecondTestEntityZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrOne", request.EntityDto.SecondTestEntityZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.SecondTestEntityZeroOrOne is not null)
		{
			var relatedEntity = await SecondTestEntityZeroOrOneFactory.CreateEntityAsync(request.EntityDto.SecondTestEntityZeroOrOne, request.CultureCode);
			entityToCreate.CreateRefToSecondTestEntityZeroOrOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityZeroOrOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}