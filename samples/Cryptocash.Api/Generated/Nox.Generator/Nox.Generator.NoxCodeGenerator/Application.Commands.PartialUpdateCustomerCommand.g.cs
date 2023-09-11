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

public class PartialUpdateCustomerCommandHandler: CommandBase<PartialUpdateCustomerCommand, Customer>, IRequestHandler<PartialUpdateCustomerCommand, CustomerKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Customer> EntityMapper { get; }

	public PartialUpdateCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Customer> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CustomerKeyDto?> Handle(PartialUpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Customer,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Customer>(), request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CustomerKeyDto(entity.Id.Value);
	}
}