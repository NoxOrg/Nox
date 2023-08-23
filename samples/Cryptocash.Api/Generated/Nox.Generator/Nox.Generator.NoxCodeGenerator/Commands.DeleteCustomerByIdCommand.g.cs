// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Commands;

public record DeleteCustomerByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteCustomerByIdCommandHandler: CommandBase, IRequestHandler<DeleteCustomerByIdCommand, bool>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public CryptocashApiDbContext DbContext { get; }

	public DeleteCustomerByIdCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<bool> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<Customer,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}
		var deletedBy = _userProvider.GetUser();
		var deletedVia = _systemProvider.GetSystem();
		entity.Deleted(deletedBy, deletedVia);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}