﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public record UpdateCountryCommand(System.String keyId, CountryUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryKeyDto?>;

internal partial class UpdateCountryCommandHandler : UpdateCountryCommandHandlerBase
{
	public UpdateCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCountryCommandHandlerBase : CommandBase<UpdateCountryCommand, CountryEntity>, IRequestHandler<UpdateCountryCommand, CountryKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> _entityFactory;

	public UpdateCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryKeyDto?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.keyId);

		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var currencyKey = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityDto.CurrencyId);
		var currencyEntity = await DbContext.Currencies.FindAsync(currencyKey);
						
		if(currencyEntity is not null)
			entity.CreateRefToCurrency(currencyEntity);
		else
			throw new RelatedEntityNotFoundException("Currency", request.EntityDto.CurrencyId.ToString());

		await DbContext.Entry(entity).Collection(x => x.Commissions).LoadAsync();
		var commissionsEntities = new List<Cryptocash.Domain.Commission>();
		foreach(var relatedEntityId in request.EntityDto.CommissionsId)
		{
			var relatedKey = Cryptocash.Domain.CommissionMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Commissions.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				commissionsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Commissions", relatedEntityId.ToString());
		}
		entity.UpdateRefToCommissions(commissionsEntities);

		await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
		var vendingMachinesEntities = new List<Cryptocash.Domain.VendingMachine>();
		foreach(var relatedEntityId in request.EntityDto.VendingMachinesId)
		{
			var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				vendingMachinesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachines", relatedEntityId.ToString());
		}
		entity.UpdateRefToVendingMachines(vendingMachinesEntities);

		await DbContext.Entry(entity).Collection(x => x.Customers).LoadAsync();
		var customersEntities = new List<Cryptocash.Domain.Customer>();
		foreach(var relatedEntityId in request.EntityDto.CustomersId)
		{
			var relatedKey = Cryptocash.Domain.CustomerMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Customers.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				customersEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Customers", relatedEntityId.ToString());
		}
		entity.UpdateRefToCustomers(customersEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryKeyDto(entity.Id.Value);
	}
}