// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using Workplace = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public record DeleteWorkplaceByIdCommand(System.Guid keyId) : IRequest<bool>;

public class DeleteWorkplaceByIdCommandHandler: CommandBase<DeleteWorkplaceByIdCommand,Workplace>, IRequestHandler<DeleteWorkplaceByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteWorkplaceByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteWorkplaceByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Workplace,DatabaseGuid>("Id", request.keyId);

		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		OnCompleted(entity);DbContext.Workplaces.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}