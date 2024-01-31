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
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateThirdTestEntityOneOrManyCommand(ThirdTestEntityOneOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<ThirdTestEntityOneOrManyKeyDto>;

internal partial class CreateThirdTestEntityOneOrManyCommandHandler : CreateThirdTestEntityOneOrManyCommandHandlerBase
{
	public CreateThirdTestEntityOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrMany, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> ThirdTestEntityZeroOrManyFactory,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution,ThirdTestEntityZeroOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateThirdTestEntityOneOrManyCommandHandlerBase : CommandBase<CreateThirdTestEntityOneOrManyCommand,ThirdTestEntityOneOrManyEntity>, IRequestHandler <CreateThirdTestEntityOneOrManyCommand, ThirdTestEntityOneOrManyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrMany, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> ThirdTestEntityZeroOrManyFactory;

	protected CreateThirdTestEntityOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrMany, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> ThirdTestEntityZeroOrManyFactory,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.ThirdTestEntityZeroOrManyFactory = ThirdTestEntityZeroOrManyFactory;
	}

	public virtual async Task<ThirdTestEntityOneOrManyKeyDto> Handle(CreateThirdTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.ThirdTestEntityZeroOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.ThirdTestEntityZeroOrManiesId)
			{
				var relatedKey = Dto.ThirdTestEntityZeroOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<ThirdTestEntityZeroOrMany>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToThirdTestEntityZeroOrManies(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("ThirdTestEntityZeroOrManies", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.ThirdTestEntityZeroOrManies)
			{
				var relatedEntity = await ThirdTestEntityZeroOrManyFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToThirdTestEntityZeroOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<ThirdTestEntityOneOrMany>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new ThirdTestEntityOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}