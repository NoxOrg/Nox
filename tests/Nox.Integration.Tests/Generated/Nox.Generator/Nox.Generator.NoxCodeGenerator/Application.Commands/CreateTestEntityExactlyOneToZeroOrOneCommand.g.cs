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

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityExactlyOneToZeroOrOneCommand(TestEntityExactlyOneToZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityExactlyOneToZeroOrOneKeyDto>;

internal partial class CreateTestEntityExactlyOneToZeroOrOneCommandHandler : CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase
{
	public CreateTestEntityExactlyOneToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> TestEntityZeroOrOneToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityZeroOrOneToExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneToZeroOrOneCommand,TestEntityExactlyOneToZeroOrOneEntity>, IRequestHandler <CreateTestEntityExactlyOneToZeroOrOneCommand, TestEntityExactlyOneToZeroOrOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> TestEntityZeroOrOneToExactlyOneFactory;

	public CreateTestEntityExactlyOneToZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> TestEntityZeroOrOneToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrOneToExactlyOneFactory = TestEntityZeroOrOneToExactlyOneFactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrOneKeyDto> Handle(CreateTestEntityExactlyOneToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityZeroOrOneToExactlyOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrOneToExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityZeroOrOneToExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToExactlyOne", request.EntityDto.TestEntityZeroOrOneToExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityZeroOrOneToExactlyOne is not null)
		{
			var relatedEntity = TestEntityZeroOrOneToExactlyOneFactory.CreateEntity(request.EntityDto.TestEntityZeroOrOneToExactlyOne);
			entityToCreate.CreateRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityExactlyOneToZeroOrOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}