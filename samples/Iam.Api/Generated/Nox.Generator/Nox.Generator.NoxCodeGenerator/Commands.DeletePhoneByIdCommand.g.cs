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

public record DeletePhoneByIdCommand(System.String keyPhoneNumber) : IRequest<bool>;

public class DeletePhoneByIdCommandHandler: CommandBase<DeletePhoneByIdCommand,Phone>, IRequestHandler<DeletePhoneByIdCommand, bool>
{
	public IamApiDbContext DbContext { get; }

	public DeletePhoneByIdCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeletePhoneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyPhoneNumber = CreateNoxTypeForKey<Phone,PhoneNumber>("PhoneNumber", request.keyPhoneNumber);

		var entity = await DbContext.Phones.FindAsync(keyPhoneNumber);
		if (entity == null)
		{
			return false;
		}

		OnCompleted(entity);DbContext.Phones.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}