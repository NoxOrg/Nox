﻿﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public record CreateRatingProgramCommand(RatingProgramCreateDto EntityDto) : IRequest<RatingProgramKeyDto>;

internal partial class CreateRatingProgramCommandHandler : CreateRatingProgramCommandHandlerBase
{
	public CreateRatingProgramCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateRatingProgramCommandHandlerBase : CommandBase<CreateRatingProgramCommand,RatingProgramEntity>, IRequestHandler <CreateRatingProgramCommand, RatingProgramKeyDto>
{
	protected readonly ClientApiDbContext DbContext;
	protected readonly IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> EntityFactory;

	public CreateRatingProgramCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<RatingProgramKeyDto> Handle(CreateRatingProgramCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.RatingPrograms.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new RatingProgramKeyDto(entityToCreate.StoreId.Value, entityToCreate.Id.Value);
	}
}