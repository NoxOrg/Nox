// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Customer = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public record DeleteCustomerByIdCommand(System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

public class DeleteCustomerByIdCommandHandler:DeleteCustomerByIdCommandHandlerBase
{
	public DeleteCustomerByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(dbContext, noxSolution, serviceProvider)
	{
	}
}
public abstract class DeleteCustomerByIdCommandHandlerBase: CommandBase<DeleteCustomerByIdCommand,Customer>, IRequestHandler<DeleteCustomerByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteCustomerByIdCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Customer,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null || entity.IsDeleted == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}