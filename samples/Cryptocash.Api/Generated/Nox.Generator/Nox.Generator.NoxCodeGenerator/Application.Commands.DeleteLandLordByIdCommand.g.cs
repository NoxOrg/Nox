// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using LandLord = CryptocashApi.Domain.LandLord;

namespace CryptocashApi.Application.Commands;

public record DeleteLandLordByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteLandLordByIdCommandHandler: CommandBase<DeleteLandLordByIdCommand,LandLord>, IRequestHandler<DeleteLandLordByIdCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public DeleteLandLordByIdCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteLandLordByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<LandLord,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.LandLords.FindAsync(keyId);
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