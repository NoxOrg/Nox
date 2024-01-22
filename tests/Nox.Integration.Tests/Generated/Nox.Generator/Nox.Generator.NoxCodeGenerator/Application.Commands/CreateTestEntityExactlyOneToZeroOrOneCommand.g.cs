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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityExactlyOneToZeroOrOneCommand(TestEntityExactlyOneToZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityExactlyOneToZeroOrOneKeyDto>;

internal partial class CreateTestEntityExactlyOneToZeroOrOneCommandHandler : CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase
{
	public CreateTestEntityExactlyOneToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> TestEntityZeroOrOneToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityZeroOrOneToExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneToZeroOrOneCommand,TestEntityExactlyOneToZeroOrOneEntity>, IRequestHandler <CreateTestEntityExactlyOneToZeroOrOneCommand, TestEntityExactlyOneToZeroOrOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> TestEntityZeroOrOneToExactlyOneFactory;

	protected CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> TestEntityZeroOrOneToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrOneToExactlyOneFactory = TestEntityZeroOrOneToExactlyOneFactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrOneKeyDto> Handle(CreateTestEntityExactlyOneToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityZeroOrOneToExactlyOneId is not null)
		{
			var relatedKey = Dto.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrOneToExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestEntityZeroOrOneToExactlyOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToExactlyOne", request.EntityDto.TestEntityZeroOrOneToExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrOneToExactlyOne is not null)
		{
			var relatedEntity = await TestEntityZeroOrOneToExactlyOneFactory.CreateEntityAsync(request.EntityDto.TestEntityZeroOrOneToExactlyOne, request.CultureCode);
			entityToCreate.CreateRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityExactlyOneToZeroOrOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityExactlyOneToZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}