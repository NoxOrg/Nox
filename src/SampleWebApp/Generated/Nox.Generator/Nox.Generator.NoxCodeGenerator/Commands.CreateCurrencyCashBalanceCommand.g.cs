﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
public record CreateCurrencyCashBalanceCommand(CurrencyCashBalanceCreateDto EntityDto) : IRequest<CurrencyCashBalanceKeyDto>;

public class CreateCurrencyCashBalanceCommandHandler: IRequestHandler<CreateCurrencyCashBalanceCommand, CurrencyCashBalanceKeyDto>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public SampleWebAppDbContext DbContext { get; }
	public IEntityFactory<CurrencyCashBalanceCreateDto,CurrencyCashBalance> EntityFactory { get; }

	public CreateCurrencyCashBalanceCommandHandler(
		SampleWebAppDbContext dbContext,
		IEntityFactory<CurrencyCashBalanceCreateDto,CurrencyCashBalance> entityFactory,
		IUserProvider userProvider,
		ISystemProvider systemProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<CurrencyCashBalanceKeyDto> Handle(CreateCurrencyCashBalanceCommand request, CancellationToken cancellationToken)
	{
		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		var createdBy = _userProvider.GetUser();
		var createdVia = _systemProvider.GetSystem();
		entityToCreate.Created(createdBy, createdVia);
	
		DbContext.CurrencyCashBalances.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyCashBalanceKeyDto(entityToCreate.StoreId.Value, entityToCreate.CurrencyId.Value);
	}
}