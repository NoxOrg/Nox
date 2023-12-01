// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public partial record DeleteCustomerByIdCommand(IEnumerable<CustomerKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteCustomerByIdCommandHandler : DeleteCustomerByIdCommandHandlerBase
{
	public DeleteCustomerByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCustomerByIdCommandHandlerBase : CommandBase<DeleteCustomerByIdCommand, CustomerEntity>, IRequestHandler<DeleteCustomerByIdCommand, bool>
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
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Customers.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new CustomerEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}