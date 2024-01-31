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
using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record CreateThirdTestEntityZeroOrOneCommand(ThirdTestEntityZeroOrOneCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<ThirdTestEntityZeroOrOneKeyDto>;

internal partial class CreateThirdTestEntityZeroOrOneCommandHandler : CreateThirdTestEntityZeroOrOneCommandHandlerBase
{
	public CreateThirdTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityExactlyOne, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> ThirdTestEntityExactlyOneFactory,
		IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> entityFactory)
		: base(repository, noxSolution,ThirdTestEntityExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateThirdTestEntityZeroOrOneCommandHandlerBase : CommandBase<CreateThirdTestEntityZeroOrOneCommand,ThirdTestEntityZeroOrOneEntity>, IRequestHandler <CreateThirdTestEntityZeroOrOneCommand, ThirdTestEntityZeroOrOneKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.ThirdTestEntityExactlyOne, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> ThirdTestEntityExactlyOneFactory;

	protected CreateThirdTestEntityZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.ThirdTestEntityExactlyOne, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> ThirdTestEntityExactlyOneFactory,
		IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.ThirdTestEntityExactlyOneFactory = ThirdTestEntityExactlyOneFactory;
	}

	public virtual async Task<ThirdTestEntityZeroOrOneKeyDto> Handle(CreateThirdTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.ThirdTestEntityExactlyOneId is not null)
		{
			var relatedKey = Dto.ThirdTestEntityExactlyOneMetadata.CreateId(request.EntityDto.ThirdTestEntityExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<ThirdTestEntityExactlyOne>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToThirdTestEntityExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("ThirdTestEntityExactlyOne", request.EntityDto.ThirdTestEntityExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.ThirdTestEntityExactlyOne is not null)
		{
			var relatedEntity = await ThirdTestEntityExactlyOneFactory.CreateEntityAsync(request.EntityDto.ThirdTestEntityExactlyOne, request.CultureCode);
			entityToCreate.CreateRefToThirdTestEntityExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<ThirdTestEntityZeroOrOne>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new ThirdTestEntityZeroOrOneKeyDto(entityToCreate.Id.Value);
	}
}