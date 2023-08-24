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

public record DeleteEmailAddressByIdCommand(System.String keyEmail) : IRequest<bool>;

public class DeleteEmailAddressByIdCommandHandler: CommandBase<DeleteEmailAddressByIdCommand,EmailAddress>, IRequestHandler<DeleteEmailAddressByIdCommand, bool>
{
	public IamApiDbContext DbContext { get; }

	public DeleteEmailAddressByIdCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteEmailAddressByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyEmail = CreateNoxTypeForKey<EmailAddress,Email>("Email", request.keyEmail);

		var entity = await DbContext.EmailAddresses.FindAsync(keyEmail);
		if (entity == null)
		{
			return false;
		}

		OnCompleted(entity);DbContext.EmailAddresses.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}