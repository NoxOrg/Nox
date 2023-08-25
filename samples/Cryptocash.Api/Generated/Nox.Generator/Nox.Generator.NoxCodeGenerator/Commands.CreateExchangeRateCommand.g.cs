﻿﻿// Generated

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
public record CreateExchangeRateCommand(ExchangeRateCreateDto EntityDto) : IRequest<ExchangeRateKeyDto>;

public partial class CreateExchangeRateCommandHandler: CommandBase<CreateExchangeRateCommand>, IRequestHandler <CreateExchangeRateCommand, ExchangeRateKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<ExchangeRateCreateDto,ExchangeRate> EntityFactory { get; }

	public CreateExchangeRateCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<ExchangeRateCreateDto,ExchangeRate> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<ExchangeRateKeyDto> Handle(CreateExchangeRateCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.ExchangeRates.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ExchangeRateKeyDto(entityToCreate.Id.Value);
	}
}