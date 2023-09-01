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
public record CreateExchangeRateCommand(ExchangeRateCreateDto EntityDto) : IRequest<ExchangeRateKeyDto>;

public partial class CreateExchangeRateCommandHandler: CommandBase<CreateExchangeRateCommand,ExchangeRate>, IRequestHandler <CreateExchangeRateCommand, ExchangeRateKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<ExchangeRateCreateDto,ExchangeRate> EntityFactory { get; }

	public CreateExchangeRateCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<ExchangeRateCreateDto,ExchangeRate> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<ExchangeRateKeyDto> Handle(CreateExchangeRateCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.ExchangeRates.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ExchangeRateKeyDto(entityToCreate.Id.Value);
	}
}