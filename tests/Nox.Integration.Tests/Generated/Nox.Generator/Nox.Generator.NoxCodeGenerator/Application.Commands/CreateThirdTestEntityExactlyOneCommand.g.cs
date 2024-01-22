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
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record CreateThirdTestEntityExactlyOneCommand(ThirdTestEntityExactlyOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<ThirdTestEntityExactlyOneKeyDto>;

internal partial class CreateThirdTestEntityExactlyOneCommandHandler : CreateThirdTestEntityExactlyOneCommandHandlerBase
{
	public CreateThirdTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrOne, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> ThirdTestEntityZeroOrOneFactory,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory)
		: base(repository, noxSolution,ThirdTestEntityZeroOrOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateThirdTestEntityExactlyOneCommandHandlerBase : CommandBase<CreateThirdTestEntityExactlyOneCommand,ThirdTestEntityExactlyOneEntity>, IRequestHandler <CreateThirdTestEntityExactlyOneCommand, ThirdTestEntityExactlyOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrOne, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> ThirdTestEntityZeroOrOneFactory;

	protected CreateThirdTestEntityExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityZeroOrOne, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> ThirdTestEntityZeroOrOneFactory,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.ThirdTestEntityZeroOrOneFactory = ThirdTestEntityZeroOrOneFactory;
	}

	public virtual async Task<ThirdTestEntityExactlyOneKeyDto> Handle(CreateThirdTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.ThirdTestEntityZeroOrOneId is not null)
		{
			var relatedKey = Dto.ThirdTestEntityZeroOrOneMetadata.CreateId(request.EntityDto.ThirdTestEntityZeroOrOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<ThirdTestEntityZeroOrOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToThirdTestEntityZeroOrOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("ThirdTestEntityZeroOrOne", request.EntityDto.ThirdTestEntityZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.ThirdTestEntityZeroOrOne is not null)
		{
			var relatedEntity = await ThirdTestEntityZeroOrOneFactory.CreateEntityAsync(request.EntityDto.ThirdTestEntityZeroOrOne, request.CultureCode);
			entityToCreate.CreateRefToThirdTestEntityZeroOrOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<ThirdTestEntityExactlyOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new ThirdTestEntityExactlyOneKeyDto(entityToCreate.Id.Value);
	}
}