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

namespace SampleWebApp.Application.Commands;
public record CreateCurrencyCashBalanceCommand(CurrencyCashBalanceCreateDto EntityDto) : IRequest<CurrencyCashBalanceKeyDto>;

public partial class CreateCurrencyCashBalanceCommandHandler: CommandBase<CreateCurrencyCashBalanceCommand,CurrencyCashBalance>, IRequestHandler <CreateCurrencyCashBalanceCommand, CurrencyCashBalanceKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityFactory<CurrencyCashBalanceCreateDto,CurrencyCashBalance> EntityFactory { get; }

	public CreateCurrencyCashBalanceCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CurrencyCashBalanceCreateDto,CurrencyCashBalance> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CurrencyCashBalanceKeyDto> Handle(CreateCurrencyCashBalanceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.CurrencyCashBalances.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyCashBalanceKeyDto{ StoreId = entityToCreate.StoreId.Value, CurrencyId = entityToCreate.CurrencyId.Value };
	}
}