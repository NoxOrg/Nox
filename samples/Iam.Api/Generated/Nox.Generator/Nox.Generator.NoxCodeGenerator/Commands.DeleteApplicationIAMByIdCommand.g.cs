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

public record DeleteApplicationIAMByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteApplicationIAMByIdCommandHandler: CommandBase<DeleteApplicationIAMByIdCommand,ApplicationIAM>, IRequestHandler<DeleteApplicationIAMByIdCommand, bool>
{
	public IamApiDbContext DbContext { get; }

	public DeleteApplicationIAMByIdCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteApplicationIAMByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<ApplicationIAM,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.ApplicationIAMs.FindAsync(keyId);
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