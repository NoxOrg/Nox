﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using RatingProgram = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public record CreateRatingProgramCommand(RatingProgramCreateDto EntityDto) : IRequest<RatingProgramKeyDto>;

internal partial class CreateRatingProgramCommandHandler: CreateRatingProgramCommandHandlerBase
{
	public CreateRatingProgramCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<RatingProgram, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateRatingProgramCommandHandlerBase: CommandBase<CreateRatingProgramCommand,RatingProgram>, IRequestHandler <CreateRatingProgramCommand, RatingProgramKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<RatingProgram, RatingProgramCreateDto, RatingProgramUpdateDto> _entityFactory;

	public CreateRatingProgramCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<RatingProgram, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<RatingProgramKeyDto> Handle(CreateRatingProgramCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);

		OnCompleted(request, entityToCreate);
		_dbContext.RatingPrograms.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new RatingProgramKeyDto(entityToCreate.StoreId.Value, entityToCreate.Id.Value);
	}
}