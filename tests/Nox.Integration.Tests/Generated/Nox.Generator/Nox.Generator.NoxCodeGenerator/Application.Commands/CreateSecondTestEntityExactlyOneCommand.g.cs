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
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record CreateSecondTestEntityExactlyOneCommand(SecondTestEntityExactlyOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<SecondTestEntityExactlyOneKeyDto>;

internal partial class CreateSecondTestEntityExactlyOneCommandHandler : CreateSecondTestEntityExactlyOneCommandHandlerBase
{
	public CreateSecondTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> TestEntityExactlyOneFactory,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateSecondTestEntityExactlyOneCommandHandlerBase : CommandBase<CreateSecondTestEntityExactlyOneCommand,SecondTestEntityExactlyOneEntity>, IRequestHandler <CreateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> TestEntityExactlyOneFactory;

	protected CreateSecondTestEntityExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityExactlyOne, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> TestEntityExactlyOneFactory,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityExactlyOneFactory = TestEntityExactlyOneFactory;
	}

	public virtual async Task<SecondTestEntityExactlyOneKeyDto> Handle(CreateSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityExactlyOneId is not null)
		{
			var relatedKey = Dto.TestEntityExactlyOneMetadata.CreateId(request.EntityDto.TestEntityExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestEntityExactlyOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityExactlyOne", request.EntityDto.TestEntityExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityExactlyOne is not null)
		{
			var relatedEntity = await TestEntityExactlyOneFactory.CreateEntityAsync(request.EntityDto.TestEntityExactlyOne, request.CultureCode);
			entityToCreate.CreateRefToTestEntityExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<SecondTestEntityExactlyOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new SecondTestEntityExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}