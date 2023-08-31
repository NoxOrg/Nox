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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;
using LandLord = CryptocashApi.Domain.LandLord;

namespace CryptocashApi.Application.Commands;
public record CreateLandLordCommand(LandLordCreateDto EntityDto) : IRequest<LandLordKeyDto>;

public partial class CreateLandLordCommandHandler: CommandBase<CreateLandLordCommand,LandLord>, IRequestHandler <CreateLandLordCommand, LandLordKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<LandLordCreateDto,LandLord> EntityFactory { get; }

	public CreateLandLordCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<LandLordCreateDto,LandLord> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<LandLordKeyDto> Handle(CreateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.LandLords.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new LandLordKeyDto(entityToCreate.Id.Value);
	}
}