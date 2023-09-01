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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using MinimumCashStock = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;
public record CreateMinimumCashStockCommand(MinimumCashStockCreateDto EntityDto) : IRequest<MinimumCashStockKeyDto>;

public partial class CreateMinimumCashStockCommandHandler: CommandBase<CreateMinimumCashStockCommand,MinimumCashStock>, IRequestHandler <CreateMinimumCashStockCommand, MinimumCashStockKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<MinimumCashStockCreateDto,MinimumCashStock> EntityFactory { get; }

	public CreateMinimumCashStockCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<MinimumCashStockCreateDto,MinimumCashStock> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<MinimumCashStockKeyDto> Handle(CreateMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.MinimumCashStocks.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new MinimumCashStockKeyDto(entityToCreate.Id.Value);
	}
}