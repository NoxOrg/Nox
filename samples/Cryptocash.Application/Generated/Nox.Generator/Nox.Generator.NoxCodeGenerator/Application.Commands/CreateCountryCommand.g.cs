﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public partial record CreateCountryCommand(CountryCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryKeyDto>;

internal partial class CreateCountryCommandHandler : CreateCountryCommandHandlerBase
{
	public CreateCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory,
		IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(repository, noxSolution,CurrencyFactory, CommissionFactory, VendingMachineFactory, CustomerFactory, entityFactory)
	{
	}
}


internal abstract class CreateCountryCommandHandlerBase : CommandBase<CreateCountryCommand,CountryEntity>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory;

	protected CreateCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory,
		IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
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

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.CurrencyId is not null)
		{
			var relatedKey = Dto.CurrencyMetadata.CreateId(request.EntityDto.CurrencyId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<Currency>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCurrency(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Currency", request.EntityDto.CurrencyId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.Currency is not null)
		{
			var relatedEntity = await CurrencyFactory.CreateEntityAsync(request.EntityDto.Currency, request.CultureCode);
			entityToCreate.CreateRefToCurrency(relatedEntity);
		}
		if(request.EntityDto.CommissionsId.Any())
		{
			foreach(var relatedId in request.EntityDto.CommissionsId)
			{
				var relatedKey = Dto.CommissionMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<Commission>(relatedKey);

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
				var relatedEntity = await CommissionFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToCommissions(relatedEntity);
			}
		}
		if(request.EntityDto.VendingMachinesId.Any())
		{
			foreach(var relatedId in request.EntityDto.VendingMachinesId)
			{
				var relatedKey = Dto.VendingMachineMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<VendingMachine>(relatedKey);

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
				var relatedEntity = await VendingMachineFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToVendingMachines(relatedEntity);
			}
		}
		if(request.EntityDto.CustomersId.Any())
		{
			foreach(var relatedId in request.EntityDto.CustomersId)
			{
				var relatedKey = Dto.CustomerMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<Customer>(relatedKey);

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
				var relatedEntity = await CustomerFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToCustomers(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<Country>(entityToCreate);
		await Repository.SaveChangesAsync();
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