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

public record DeleteOwnedEntityByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteOwnedEntityByIdCommandHandler: CommandBase, IRequestHandler<DeleteOwnedEntityByIdCommand, bool>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public ClientApiDbContext DbContext { get; }

	public DeleteOwnedEntityByIdCommandHandler(
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

	public async Task<bool> Handle(DeleteOwnedEntityByIdCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<OwnedEntity,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.OwnedEntities.FindAsync(keyId);
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