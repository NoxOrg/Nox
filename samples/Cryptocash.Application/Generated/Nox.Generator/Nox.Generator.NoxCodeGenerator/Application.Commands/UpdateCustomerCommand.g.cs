﻿﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public partial record UpdateCustomerCommand(System.Guid keyId, CustomerUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CustomerKeyDto>;

internal partial class UpdateCustomerCommandHandler : UpdateCustomerCommandHandlerBase
{
	public UpdateCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCustomerCommandHandlerBase : CommandBase<UpdateCustomerCommand, CustomerEntity>, IRequestHandler<UpdateCustomerCommand, CustomerKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> _entityFactory;
	protected UpdateCustomerCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CustomerKeyDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.CustomerMetadata.CreateId(request.keyId);

		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new CustomerKeyDto(entity.Id.Value);
	}
}