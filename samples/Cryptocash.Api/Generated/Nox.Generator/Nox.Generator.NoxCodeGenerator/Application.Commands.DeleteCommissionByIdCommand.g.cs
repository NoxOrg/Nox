// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using Commission = CryptocashApi.Domain.Commission;

namespace CryptocashApi.Application.Commands;

public record DeleteCommissionByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteCommissionByIdCommandHandler: CommandBase<DeleteCommissionByIdCommand,Commission>, IRequestHandler<DeleteCommissionByIdCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public DeleteCommissionByIdCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteCommissionByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Commission,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.Commissions.FindAsync(keyId);
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