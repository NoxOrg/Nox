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
using CashStockOrder = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;
public record CreateCashStockOrderCommand(CashStockOrderCreateDto EntityDto) : IRequest<CashStockOrderKeyDto>;

public partial class CreateCashStockOrderCommandHandler: CommandBase<CreateCashStockOrderCommand,CashStockOrder>, IRequestHandler <CreateCashStockOrderCommand, CashStockOrderKeyDto>
{
	public CryptocashDbContext DbContext { get; }

	public CreateCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<CashStockOrderKeyDto> Handle(CreateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();
	
		OnCompleted(entityToCreate);
		DbContext.CashStockOrders.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CashStockOrderKeyDto(entityToCreate.Id.Value);
	}
}