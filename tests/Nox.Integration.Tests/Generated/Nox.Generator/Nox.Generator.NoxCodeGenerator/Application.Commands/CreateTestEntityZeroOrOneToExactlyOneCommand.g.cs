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
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrOneToExactlyOneCommand(TestEntityZeroOrOneToExactlyOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrOneToExactlyOneKeyDto>;

internal partial class CreateTestEntityZeroOrOneToExactlyOneCommandHandler : CreateTestEntityZeroOrOneToExactlyOneCommandHandlerBase
{
	public CreateTestEntityZeroOrOneToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> TestEntityExactlyOneToZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityExactlyOneToZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneToExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityZeroOrOneToExactlyOneCommand,TestEntityZeroOrOneToExactlyOneEntity>, IRequestHandler <CreateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> TestEntityExactlyOneToZeroOrOneFactory;

	protected CreateTestEntityZeroOrOneToExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> TestEntityExactlyOneToZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
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
			var relatedEntity = await Repository.FindAsync<TestEntityExactlyOneToZeroOrOne>(relatedKey);
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
		await Repository.AddAsync<TestEntityZeroOrOneToExactlyOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityZeroOrOneToExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}