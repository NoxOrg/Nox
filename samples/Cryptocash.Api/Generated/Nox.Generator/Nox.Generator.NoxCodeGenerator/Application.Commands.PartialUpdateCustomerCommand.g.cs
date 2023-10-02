﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Customer = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public record PartialUpdateCustomerCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CustomerKeyDto?>;

internal class PartialUpdateCustomerCommandHandler: PartialUpdateCustomerCommandHandlerBase
{
	public PartialUpdateCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateCustomerCommandHandlerBase: CommandBase<PartialUpdateCustomerCommand, Customer>, IRequestHandler<PartialUpdateCustomerCommand, CustomerKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> EntityFactory { get; }

	public PartialUpdateCustomerCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CustomerKeyDto?> Handle(PartialUpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.keyId);

		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CustomerKeyDto(entity.Id.Value);
	}
}