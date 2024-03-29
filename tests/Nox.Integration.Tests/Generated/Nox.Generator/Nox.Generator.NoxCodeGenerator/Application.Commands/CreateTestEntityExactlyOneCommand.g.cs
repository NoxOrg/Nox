﻿﻿// Generated

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
using TestEntityExactlyOneEntity = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityExactlyOneCommand(TestEntityExactlyOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityExactlyOneKeyDto>;

internal partial class CreateTestEntityExactlyOneCommandHandler : CreateTestEntityExactlyOneCommandHandlerBase
{
	public CreateTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> SecondTestEntityExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory)
		: base(repository, noxSolution,SecondTestEntityExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneCommand,TestEntityExactlyOneEntity>, IRequestHandler <CreateTestEntityExactlyOneCommand, TestEntityExactlyOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> SecondTestEntityExactlyOneFactory;

	protected CreateTestEntityExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.SecondTestEntityExactlyOne, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> SecondTestEntityExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.SecondTestEntityExactlyOneFactory = SecondTestEntityExactlyOneFactory;
	}

	public virtual async Task<TestEntityExactlyOneKeyDto> Handle(CreateTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.SecondTestEntityExactlyOneId is not null)
		{
			var relatedKey = Dto.SecondTestEntityExactlyOneMetadata.CreateId(request.EntityDto.SecondTestEntityExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<TestWebApp.Domain.SecondTestEntityExactlyOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToSecondTestEntityExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("SecondTestEntityExactlyOne", request.EntityDto.SecondTestEntityExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.SecondTestEntityExactlyOne is not null)
		{
			var relatedEntity = await SecondTestEntityExactlyOneFactory.CreateEntityAsync(request.EntityDto.SecondTestEntityExactlyOne, request.CultureCode);
			entityToCreate.CreateRefToSecondTestEntityExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestWebApp.Domain.TestEntityExactlyOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TestEntityExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}