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
using ExchangeRate = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Commands;
public record CreateExchangeRateCommand(ExchangeRateCreateDto EntityDto) : IRequest<ExchangeRateKeyDto>;

public partial class CreateExchangeRateCommandHandler: CommandBase<CreateExchangeRateCommand,ExchangeRate>, IRequestHandler <CreateExchangeRateCommand, ExchangeRateKeyDto>
{
	public CryptocashDbContext DbContext { get; }

	public CreateExchangeRateCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<ExchangeRateKeyDto> Handle(CreateExchangeRateCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();
	
		OnCompleted(entityToCreate);
		DbContext.ExchangeRates.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ExchangeRateKeyDto(entityToCreate.Id.Value);
	}
}