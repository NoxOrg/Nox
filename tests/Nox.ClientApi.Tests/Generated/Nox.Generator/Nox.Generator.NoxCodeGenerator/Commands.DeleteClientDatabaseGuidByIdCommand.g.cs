// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;

namespace ClientApi.Application.Commands;

public record DeleteClientDatabaseGuidByIdCommand(System.Guid keyId) : IRequest<bool>;

public class DeleteClientDatabaseGuidByIdCommandHandler: CommandBase<DeleteClientDatabaseGuidByIdCommand,ClientDatabaseGuid>, IRequestHandler<DeleteClientDatabaseGuidByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteClientDatabaseGuidByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteClientDatabaseGuidByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<ClientDatabaseGuid,DatabaseGuid>("Id", request.keyId);

		var entity = await DbContext.ClientDatabaseGuids.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}DbContext.ClientDatabaseGuids.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}