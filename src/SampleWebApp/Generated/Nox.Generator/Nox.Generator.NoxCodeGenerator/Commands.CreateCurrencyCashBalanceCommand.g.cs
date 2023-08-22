﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
public record CreateCurrencyCashBalanceCommand(CurrencyCashBalanceCreateDto EntityDto) : IRequest<CurrencyCashBalanceKeyDto>;

public class CreateCurrencyCashBalanceCommandHandler: IRequestHandler<CreateCurrencyCashBalanceCommand, CurrencyCashBalanceKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityFactory<CurrencyCashBalanceCreateDto,CurrencyCashBalance> EntityFactory { get; }

	public CreateCurrencyCashBalanceCommandHandler(
		SampleWebAppDbContext dbContext,
		IEntityFactory<CurrencyCashBalanceCreateDto,CurrencyCashBalance> entityFactory)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CurrencyCashBalanceKeyDto> Handle(CreateCurrencyCashBalanceCommand request, CancellationToken cancellationToken)
	{
		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.CurrencyCashBalances.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyCashBalanceKeyDto(entityToCreate.StoreId.Value, entityToCreate.CurrencyId.Value);
	}
}