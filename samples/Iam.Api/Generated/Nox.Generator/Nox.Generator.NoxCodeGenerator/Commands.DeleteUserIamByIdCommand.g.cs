// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using IamApi.Infrastructure.Persistence;
using IamApi.Domain;

namespace IamApi.Application.Commands;

public record DeleteUserIamByIdCommand(System.Guid keyId) : IRequest<bool>;

public class DeleteUserIamByIdCommandHandler: CommandBase<DeleteUserIamByIdCommand,UserIam>, IRequestHandler<DeleteUserIamByIdCommand, bool>
{
	public IamApiDbContext DbContext { get; }

	public DeleteUserIamByIdCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteUserIamByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<UserIam,DatabaseGuid>("Id", request.keyId);

		var entity = await DbContext.UserIams.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}

		OnCompleted(entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}