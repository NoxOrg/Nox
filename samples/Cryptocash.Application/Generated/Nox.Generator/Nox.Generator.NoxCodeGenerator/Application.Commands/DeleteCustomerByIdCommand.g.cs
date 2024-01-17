// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public partial record DeleteCustomerByIdCommand(IEnumerable<CustomerKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCustomerByIdCommandHandler : DeleteCustomerByIdCommandHandlerBase
{
	public DeleteCustomerByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCustomerByIdCommandHandlerBase : CommandCollectionBase<DeleteCustomerByIdCommand, CustomerEntity>, IRequestHandler<DeleteCustomerByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCustomerByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
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

			var entity = await DbContext.Customers.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Customer",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}