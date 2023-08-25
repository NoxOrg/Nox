// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Commands;

public record DeleteCurrencyUnitsByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteCurrencyUnitsByIdCommandHandler: CommandBase<DeleteCurrencyUnitsByIdCommand,CurrencyUnits>, IRequestHandler<DeleteCurrencyUnitsByIdCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public DeleteCurrencyUnitsByIdCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteCurrencyUnitsByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CurrencyUnits,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CurrencyUnits.FindAsync(keyId);
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