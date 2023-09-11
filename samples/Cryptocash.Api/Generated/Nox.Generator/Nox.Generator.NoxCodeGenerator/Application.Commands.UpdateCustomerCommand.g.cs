﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Customer = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public record UpdateCustomerCommand(System.Int64 keyId, CustomerUpdateDto EntityDto, System.Guid? Etag) : IRequest<CustomerKeyDto?>;

public class UpdateCustomerCommandHandler: CommandBase<UpdateCustomerCommand, Customer>, IRequestHandler<UpdateCustomerCommand, CustomerKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Customer> EntityMapper { get; }

	public UpdateCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Customer> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<CustomerKeyDto?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Customer,AutoNumber>("Id", request.keyId);
	
		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<Customer>(), request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CustomerKeyDto(entity.Id.Value);
	}
}