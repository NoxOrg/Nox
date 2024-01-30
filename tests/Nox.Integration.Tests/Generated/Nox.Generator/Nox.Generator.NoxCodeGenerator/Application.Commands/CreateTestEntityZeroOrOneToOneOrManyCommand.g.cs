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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityZeroOrOneToOneOrManyCommand(TestEntityZeroOrOneToOneOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityZeroOrOneToOneOrManyKeyDto>;

internal partial class CreateTestEntityZeroOrOneToOneOrManyCommandHandler : CreateTestEntityZeroOrOneToOneOrManyCommandHandlerBase
{
	public CreateTestEntityZeroOrOneToOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> TestEntityOneOrManyToZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityOneOrManyToZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityZeroOrOneToOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityZeroOrOneToOneOrManyCommand,TestEntityZeroOrOneToOneOrManyEntity>, IRequestHandler <CreateTestEntityZeroOrOneToOneOrManyCommand, TestEntityZeroOrOneToOneOrManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> TestEntityOneOrManyToZeroOrOneFactory;

	protected CreateTestEntityZeroOrOneToOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> TestEntityOneOrManyToZeroOrOneFactory,
		IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityOneOrManyToZeroOrOneFactory = TestEntityOneOrManyToZeroOrOneFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToOneOrManyKeyDto> Handle(CreateTestEntityZeroOrOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityOneOrManyToZeroOrOneId is not null)
		{
			var relatedKey = Dto.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityOneOrManyToZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestEntityOneOrManyToZeroOrOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrOne", request.EntityDto.TestEntityOneOrManyToZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityOneOrManyToZeroOrOne is not null)
		{
			var relatedEntity = await TestEntityOneOrManyToZeroOrOneFactory.CreateEntityAsync(request.EntityDto.TestEntityOneOrManyToZeroOrOne, request.CultureCode);
			entityToCreate.CreateRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestEntityZeroOrOneToOneOrMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityZeroOrOneToOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}