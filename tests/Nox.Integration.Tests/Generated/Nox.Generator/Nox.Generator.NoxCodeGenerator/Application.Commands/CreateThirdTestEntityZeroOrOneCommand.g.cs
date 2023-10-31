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
using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public record CreateThirdTestEntityZeroOrOneCommand(ThirdTestEntityZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<ThirdTestEntityZeroOrOneKeyDto>;

internal partial class CreateThirdTestEntityZeroOrOneCommandHandler : CreateThirdTestEntityZeroOrOneCommandHandlerBase
{
	public CreateThirdTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityExactlyOne, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> ThirdTestEntityExactlyOneFactory,
		IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,ThirdTestEntityExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateThirdTestEntityZeroOrOneCommandHandlerBase : CommandBase<CreateThirdTestEntityZeroOrOneCommand,ThirdTestEntityZeroOrOneEntity>, IRequestHandler <CreateThirdTestEntityZeroOrOneCommand, ThirdTestEntityZeroOrOneKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.ThirdTestEntityExactlyOne, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> ThirdTestEntityExactlyOneFactory;

	public CreateThirdTestEntityZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityExactlyOne, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> ThirdTestEntityExactlyOneFactory,
		IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.ThirdTestEntityExactlyOneFactory = ThirdTestEntityExactlyOneFactory;
	}

	public virtual async Task<ThirdTestEntityZeroOrOneKeyDto> Handle(CreateThirdTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.ThirdTestEntityExactlyOneRelationshipId is not null)
		{
			var relatedKey = TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateId(request.EntityDto.ThirdTestEntityExactlyOneRelationshipId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.ThirdTestEntityExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToThirdTestEntityExactlyOneRelationship(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("ThirdTestEntityExactlyOneRelationship", request.EntityDto.ThirdTestEntityExactlyOneRelationshipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.ThirdTestEntityExactlyOneRelationship is not null)
		{
			var relatedEntity = ThirdTestEntityExactlyOneFactory.CreateEntity(request.EntityDto.ThirdTestEntityExactlyOneRelationship);
			entityToCreate.CreateRefToThirdTestEntityExactlyOneRelationship(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.ThirdTestEntityZeroOrOnes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ThirdTestEntityZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}