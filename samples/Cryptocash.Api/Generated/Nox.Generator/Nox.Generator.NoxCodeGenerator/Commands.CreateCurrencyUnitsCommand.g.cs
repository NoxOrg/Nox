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

namespace CryptocashApi.Application.Commands;
public record CreateCurrencyUnitsCommand(CurrencyUnitsCreateDto EntityDto) : IRequest<CurrencyUnitsKeyDto>;

public partial class CreateCurrencyUnitsCommandHandler: CommandBase<CreateCurrencyUnitsCommand>, IRequestHandler <CreateCurrencyUnitsCommand, CurrencyUnitsKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<CurrencyUnitsCreateDto,CurrencyUnits> EntityFactory { get; }

	public CreateCurrencyUnitsCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CurrencyUnitsCreateDto,CurrencyUnits> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CurrencyUnitsKeyDto> Handle(CreateCurrencyUnitsCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.CurrencyUnits.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyUnitsKeyDto(entityToCreate.Id.Value);
	}
}