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
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record CreateThirdTestEntityExactlyOneCommand(ThirdTestEntityExactlyOneCreateDto EntityDto) : IRequest<ThirdTestEntityExactlyOneKeyDto>;

internal partial class CreateThirdTestEntityExactlyOneCommandHandler : CreateThirdTestEntityExactlyOneCommandHandlerBase
{
	public CreateThirdTestEntityExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrOne, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> ThirdTestEntityZeroOrOneFactory,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,ThirdTestEntityZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateThirdTestEntityExactlyOneCommandHandlerBase : CommandBase<CreateThirdTestEntityExactlyOneCommand,ThirdTestEntityExactlyOneEntity>, IRequestHandler <CreateThirdTestEntityExactlyOneCommand, ThirdTestEntityExactlyOneKeyDto>
{
	protected readonly TestWebAppDbContext DbContext;
	protected readonly IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrOne, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> ThirdTestEntityZeroOrOneFactory;

	public CreateThirdTestEntityExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrOne, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> ThirdTestEntityZeroOrOneFactory,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.ThirdTestEntityZeroOrOneFactory = ThirdTestEntityZeroOrOneFactory;
	}

	public virtual async Task<ThirdTestEntityExactlyOneKeyDto> Handle(CreateThirdTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.ThirdTestEntityZeroOrOneRelationshipId is not null)
		{
			var relatedKey = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateId(request.EntityDto.ThirdTestEntityZeroOrOneRelationshipId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.ThirdTestEntityZeroOrOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToThirdTestEntityZeroOrOneRelationship(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("ThirdTestEntityZeroOrOneRelationship", request.EntityDto.ThirdTestEntityZeroOrOneRelationshipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.ThirdTestEntityZeroOrOneRelationship is not null)
		{
			var relatedEntity = ThirdTestEntityZeroOrOneFactory.CreateEntity(request.EntityDto.ThirdTestEntityZeroOrOneRelationship);
			entityToCreate.CreateRefToThirdTestEntityZeroOrOneRelationship(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.ThirdTestEntityExactlyOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ThirdTestEntityExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}