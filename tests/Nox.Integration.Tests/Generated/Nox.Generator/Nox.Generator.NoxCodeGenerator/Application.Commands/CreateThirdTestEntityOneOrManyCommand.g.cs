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
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public record CreateThirdTestEntityOneOrManyCommand(ThirdTestEntityOneOrManyCreateDto EntityDto) : IRequest<ThirdTestEntityOneOrManyKeyDto>;

internal partial class CreateThirdTestEntityOneOrManyCommandHandler : CreateThirdTestEntityOneOrManyCommandHandlerBase
{
	public CreateThirdTestEntityOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrMany, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> ThirdTestEntityZeroOrManyFactory,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,ThirdTestEntityZeroOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateThirdTestEntityOneOrManyCommandHandlerBase : CommandBase<CreateThirdTestEntityOneOrManyCommand,ThirdTestEntityOneOrManyEntity>, IRequestHandler <CreateThirdTestEntityOneOrManyCommand, ThirdTestEntityOneOrManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrMany, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> ThirdTestEntityZeroOrManyFactory;

	public CreateThirdTestEntityOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrMany, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> ThirdTestEntityZeroOrManyFactory,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.ThirdTestEntityZeroOrManyFactory = ThirdTestEntityZeroOrManyFactory;
	}

	public virtual async Task<ThirdTestEntityOneOrManyKeyDto> Handle(CreateThirdTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.ThirdTestEntityZeroOrManyRelationshipId.Any())
		{
			foreach(var relatedId in request.EntityDto.ThirdTestEntityZeroOrManyRelationshipId)
			{
				var relatedKey = TestWebApp.Domain.ThirdTestEntityZeroOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.ThirdTestEntityZeroOrManies.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToThirdTestEntityZeroOrManyRelationship(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("ThirdTestEntityZeroOrManyRelationship", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.ThirdTestEntityZeroOrManyRelationship)
			{
				var relatedEntity = ThirdTestEntityZeroOrManyFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToThirdTestEntityZeroOrManyRelationship(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.ThirdTestEntityOneOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ThirdTestEntityOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}