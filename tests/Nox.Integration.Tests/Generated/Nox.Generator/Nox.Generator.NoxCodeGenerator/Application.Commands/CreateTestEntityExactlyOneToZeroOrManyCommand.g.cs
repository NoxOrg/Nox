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
using TestEntityExactlyOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityExactlyOneToZeroOrManyCommand(TestEntityExactlyOneToZeroOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityExactlyOneToZeroOrManyKeyDto>;

internal partial class CreateTestEntityExactlyOneToZeroOrManyCommandHandler : CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase
{
	public CreateTestEntityExactlyOneToZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> TestEntityZeroOrManyToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution,TestEntityZeroOrManyToExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneToZeroOrManyCommand,TestEntityExactlyOneToZeroOrManyEntity>, IRequestHandler <CreateTestEntityExactlyOneToZeroOrManyCommand, TestEntityExactlyOneToZeroOrManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> TestEntityZeroOrManyToExactlyOneFactory;

	protected CreateTestEntityExactlyOneToZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto> TestEntityZeroOrManyToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrManyToExactlyOneFactory = TestEntityZeroOrManyToExactlyOneFactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrManyKeyDto> Handle(CreateTestEntityExactlyOneToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.TestEntityZeroOrManyToExactlyOneId is not null)
		{
			var relatedKey = Dto.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrManyToExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToExactlyOne", request.EntityDto.TestEntityZeroOrManyToExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrManyToExactlyOne is not null)
		{
			var relatedEntity = await TestEntityZeroOrManyToExactlyOneFactory.CreateEntityAsync(request.EntityDto.TestEntityZeroOrManyToExactlyOne, request.CultureCode);
			entityToCreate.CreateRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityExactlyOneToZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}