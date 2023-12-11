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
using FluentValidation;
using Microsoft.Extensions.Logging;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public partial record CreateCountryCommand(CountryCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryKeyDto>;

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

	protected CreateCountryCommandHandlerBase(
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

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);
		if(request.EntityDto.CurrencyId is not null)
		{
			var relatedKey = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityDto.CurrencyId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.Currencies.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCurrency(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Currency", request.EntityDto.CurrencyId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.Currency is not null)
		{
			var relatedEntity = await CurrencyFactory.CreateEntityAsync(request.EntityDto.Currency);
			entityToCreate.CreateRefToCurrency(relatedEntity);
		}
		if(request.EntityDto.CommissionsId.Any())
		{
			foreach(var relatedId in request.EntityDto.CommissionsId)
			{
				var relatedKey = Cryptocash.Domain.CommissionMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Commissions.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToCommissions(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Commissions", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Commissions)
			{
				var relatedEntity = await CommissionFactory.CreateEntityAsync(relatedCreateDto);
				entityToCreate.CreateRefToCommissions(relatedEntity);
			}
		}
		if(request.EntityDto.VendingMachinesId.Any())
		{
			foreach(var relatedId in request.EntityDto.VendingMachinesId)
			{
				var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToVendingMachines(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("VendingMachines", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.VendingMachines)
			{
				var relatedEntity = await VendingMachineFactory.CreateEntityAsync(relatedCreateDto);
				entityToCreate.CreateRefToVendingMachines(relatedEntity);
			}
		}
		if(request.EntityDto.CustomersId.Any())
		{
			foreach(var relatedId in request.EntityDto.CustomersId)
			{
				var relatedKey = Cryptocash.Domain.CustomerMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Customers.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToCustomers(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Customers", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Customers)
			{
				var relatedEntity = await CustomerFactory.CreateEntityAsync(relatedCreateDto);
				entityToCreate.CreateRefToCustomers(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Countries.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryValidator()
    {
		RuleFor(x => x.EntityDto.CountryTimeZones)
			.Must(owned => owned.TrueForAll(x => x.Id == null))
			.WithMessage("CountryTimeZones.Id must be null as it is auto generated.");
		RuleFor(x => x.EntityDto.Holidays)
			.Must(owned => owned.TrueForAll(x => x.Id == null))
			.WithMessage("Holidays.Id must be null as it is auto generated.");
    }
}