﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using LandLord = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public record CreateLandLordCommand(LandLordCreateDto EntityDto) : IRequest<LandLordKeyDto>;

public partial class CreateLandLordCommandHandler: CommandBase<CreateLandLordCommand,LandLord>, IRequestHandler <CreateLandLordCommand, LandLordKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<LandLordCreateDto,LandLord> _entityFactory;

	public CreateLandLordCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<LandLordCreateDto,LandLord> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public async Task<LandLordKeyDto> Handle(CreateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
					
		OnCompleted(entityToCreate);
		_dbContext.LandLords.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new LandLordKeyDto(entityToCreate.Id.Value);
	}
}