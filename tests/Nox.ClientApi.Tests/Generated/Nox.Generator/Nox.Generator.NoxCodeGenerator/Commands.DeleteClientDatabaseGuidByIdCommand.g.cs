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

public record DeleteClientDatabaseGuidByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteClientDatabaseGuidByIdCommandHandler: CommandBase, IRequestHandler<DeleteClientDatabaseGuidByIdCommand, bool>
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
		var keyId = CreateNoxTypeForKey<ClientDatabaseGuid,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.ClientDatabaseGuids.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}DbContext.ClientDatabaseGuids.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}