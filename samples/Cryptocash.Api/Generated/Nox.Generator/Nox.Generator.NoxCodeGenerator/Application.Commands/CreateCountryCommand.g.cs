﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public record CreateCountryCommand(CountryCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryKeyDto>;

internal partial class CreateCountryCommandHandler : CreateCountryCommandHandlerBase
{
	public CreateCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory,
		IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(dbContext, noxSolution,CurrencyFactory, CommissionFactory, VendingMachineFactory, CustomerFactory, entityFactory)
	{
	}
}


internal abstract class CreateCountryCommandHandlerBase : CommandBase<CreateCountryCommand,CountryEntity>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory;

	public CreateCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory,
		IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CurrencyFactory = CurrencyFactory;
		this.CommissionFactory = CommissionFactory;
		this.VendingMachineFactory = VendingMachineFactory;
		this.CustomerFactory = CustomerFactory;
	}

	public virtual async Task<CountryKeyDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CountryUsedByCurrencyId is not null)
		{
			var relatedKey = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityDto.CountryUsedByCurrencyId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.Currencies.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCountryUsedByCurrency(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CountryUsedByCurrency", request.EntityDto.CountryUsedByCurrencyId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.CountryUsedByCurrency is not null)
		{
			var relatedEntity = CurrencyFactory.CreateEntity(request.EntityDto.CountryUsedByCurrency);
			entityToCreate.CreateRefToCountryUsedByCurrency(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CountryUsedByCommissions)
		{
			var relatedEntity = CommissionFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCountryUsedByCommissions(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CountryUsedByVendingMachines)
		{
			var relatedEntity = VendingMachineFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCountryUsedByVendingMachines(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CountryUsedByCustomers)
		{
			var relatedEntity = CustomerFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCountryUsedByCustomers(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Countries.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryKeyDto(entityToCreate.Id.Value);
	}
}