// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateCustomerCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CustomerKeyDto>;

internal partial class PartialUpdateCustomerCommandHandler : PartialUpdateCustomerCommandHandlerBase
{
	public PartialUpdateCustomerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCustomerCommandHandlerBase : CommandBase<PartialUpdateCustomerCommand, CustomerEntity>, IRequestHandler<PartialUpdateCustomerCommand, CustomerKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCustomerCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CustomerKeyDto> Handle(PartialUpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.CustomerMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Cryptocash.Domain.Customer>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new CustomerKeyDto(entity.Id.Value);
	}
}