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

internal partial class UpdateCustomerCommandHandler: UpdateCustomerCommandHandlerBase
{
	public UpdateCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> entityFactory): base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCustomerCommandHandlerBase: CommandBase<UpdateCustomerCommand, Customer>, IRequestHandler<UpdateCustomerCommand, CustomerKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> _entityFactory;

	public UpdateCustomerCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CustomerKeyDto?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.keyId);

		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
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