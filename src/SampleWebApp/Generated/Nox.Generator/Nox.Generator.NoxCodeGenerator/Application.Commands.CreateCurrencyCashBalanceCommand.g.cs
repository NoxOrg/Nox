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

using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;
using CurrencyCashBalance = SampleWebApp.Domain.CurrencyCashBalance;

namespace SampleWebApp.Application.Commands;
public record CreateCurrencyCashBalanceCommand(CurrencyCashBalanceCreateDto EntityDto) : IRequest<CurrencyCashBalanceKeyDto>;

public partial class CreateCurrencyCashBalanceCommandHandler: CommandBase<CreateCurrencyCashBalanceCommand,CurrencyCashBalance>, IRequestHandler <CreateCurrencyCashBalanceCommand, CurrencyCashBalanceKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }

	public CreateCurrencyCashBalanceCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<CurrencyCashBalanceKeyDto> Handle(CreateCurrencyCashBalanceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();		
	
		OnCompleted(entityToCreate);
		DbContext.CurrencyCashBalances.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyCashBalanceKeyDto(entityToCreate.StoreId.Value, entityToCreate.CurrencyId.Value);
	}
}