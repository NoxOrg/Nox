// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;

namespace ClientApi.Application.Commands;

public record DeleteClientNuidByIdCommand(System.UInt32 keyId) : IRequest<bool>;

public class DeleteClientNuidByIdCommandHandler: CommandBase<DeleteClientNuidByIdCommand>, IRequestHandler<DeleteClientNuidByIdCommand, bool>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public ClientApiDbContext DbContext { get; }

	public DeleteClientNuidByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<bool> Handle(DeleteClientNuidByIdCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<ClientNuid,Nuid>("Id", request.keyId);

		var entity = await DbContext.ClientNuids.FindAsync(keyId);
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