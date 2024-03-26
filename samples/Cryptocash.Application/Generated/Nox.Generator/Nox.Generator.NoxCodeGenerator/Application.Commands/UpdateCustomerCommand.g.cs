﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public partial record UpdateCustomerCommand(System.Guid keyId, CustomerUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CustomerKeyDto>;

internal partial class UpdateCustomerCommandHandler : UpdateCustomerCommandHandlerBase
{
	public UpdateCustomerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCustomerCommandHandlerBase : CommandBase<UpdateCustomerCommand, CustomerEntity>, IRequestHandler<UpdateCustomerCommand, CustomerKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> EntityFactory { get; }
	protected UpdateCustomerCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CustomerKeyDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<Cryptocash.Domain.Customer>()
            .Where(x => x.Id == Dto.CustomerMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new CustomerKeyDto(entity.Id.Value);
	}
}