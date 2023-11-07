﻿// Generated

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

		var countryUsedByCurrencyKey = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityDto.CountryUsedByCurrencyId);
		var countryUsedByCurrencyEntity = await DbContext.Currencies.FindAsync(countryUsedByCurrencyKey);
						
		if(countryUsedByCurrencyEntity is not null)
			entity.CreateRefToCountryUsedByCurrency(countryUsedByCurrencyEntity);
		else
			throw new RelatedEntityNotFoundException("CountryUsedByCurrency", request.EntityDto.CountryUsedByCurrencyId.ToString());

		await DbContext.Entry(entity).Collection(x => x.CountryUsedByCommissions).LoadAsync();
		var countryUsedByCommissionsEntities = new List<Commission>();
		foreach(var relatedEntityId in request.EntityDto.CountryUsedByCommissionsId)
		{
			var relatedKey = Cryptocash.Domain.CommissionMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Commissions.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				countryUsedByCommissionsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CountryUsedByCommissions", relatedEntityId.ToString());
		}
		entity.UpdateRefToCountryUsedByCommissions(countryUsedByCommissionsEntities);

		await DbContext.Entry(entity).Collection(x => x.CountryUsedByVendingMachines).LoadAsync();
		var countryUsedByVendingMachinesEntities = new List<VendingMachine>();
		foreach(var relatedEntityId in request.EntityDto.CountryUsedByVendingMachinesId)
		{
			var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				countryUsedByVendingMachinesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CountryUsedByVendingMachines", relatedEntityId.ToString());
		}
		entity.UpdateRefToCountryUsedByVendingMachines(countryUsedByVendingMachinesEntities);

		await DbContext.Entry(entity).Collection(x => x.CountryUsedByCustomers).LoadAsync();
		var countryUsedByCustomersEntities = new List<Customer>();
		foreach(var relatedEntityId in request.EntityDto.CountryUsedByCustomersId)
		{
			var relatedKey = Cryptocash.Domain.CustomerMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Customers.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				countryUsedByCustomersEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CountryUsedByCustomers", relatedEntityId.ToString());
		}
		entity.UpdateRefToCountryUsedByCustomers(countryUsedByCustomersEntities);

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