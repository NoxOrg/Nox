// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public partial record DeleteCustomerByIdCommand(IEnumerable<CustomerKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCustomerByIdCommandHandler : DeleteCustomerByIdCommandHandlerBase
{
	public DeleteCustomerByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCustomerByIdCommandHandlerBase : CommandCollectionBase<DeleteCustomerByIdCommand, CustomerEntity>, IRequestHandler<DeleteCustomerByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCustomerByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CustomerEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.CustomerMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<CustomerEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Customer",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<CustomerEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}