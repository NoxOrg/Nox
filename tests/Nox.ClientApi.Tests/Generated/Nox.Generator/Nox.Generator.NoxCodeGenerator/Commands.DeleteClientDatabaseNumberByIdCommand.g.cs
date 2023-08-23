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

public record DeleteClientDatabaseNumberByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteClientDatabaseNumberByIdCommandHandler: CommandBase<DeleteClientDatabaseNumberByIdCommand>, IRequestHandler<DeleteClientDatabaseNumberByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteClientDatabaseNumberByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteClientDatabaseNumberByIdCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<ClientDatabaseNumber,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.ClientDatabaseNumbers.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}