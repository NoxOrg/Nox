﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public partial record CreateRatingProgramCommand(RatingProgramCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<RatingProgramKeyDto>;

internal partial class CreateRatingProgramCommandHandler : CreateRatingProgramCommandHandlerBase
{
	public CreateRatingProgramCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateRatingProgramCommandHandlerBase : CommandBase<CreateRatingProgramCommand,RatingProgramEntity>, IRequestHandler <CreateRatingProgramCommand, RatingProgramKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> EntityFactory;

	protected CreateRatingProgramCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<RatingProgramKeyDto> Handle(CreateRatingProgramCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<RatingProgram>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new RatingProgramKeyDto(entityToCreate.StoreId.Value, entityToCreate.Id.Value);
	}
}