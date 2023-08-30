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

namespace Cryptocash.Application.Commands;
public record CreateCurrencyUnitsCommand(CurrencyUnitsCreateDto EntityDto) : IRequest<CurrencyUnitsKeyDto>;

public partial class CreateCurrencyUnitsCommandHandler: CommandBase<CreateCurrencyUnitsCommand,CurrencyUnits>, IRequestHandler <CreateCurrencyUnitsCommand, CurrencyUnitsKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<CurrencyUnitsCreateDto,CurrencyUnits> EntityFactory { get; }

	public CreateCurrencyUnitsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CurrencyUnitsCreateDto,CurrencyUnits> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CurrencyUnitsKeyDto> Handle(CreateCurrencyUnitsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.CurrencyUnits.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyUnitsKeyDto(entityToCreate.Id.Value);
	}
}