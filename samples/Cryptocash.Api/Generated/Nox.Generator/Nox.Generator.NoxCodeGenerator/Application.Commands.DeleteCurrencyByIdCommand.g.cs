// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public record DeleteCurrencyByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteCurrencyByIdCommandHandler : DeleteCurrencyByIdCommandHandlerBase
{
	public DeleteCurrencyByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution): base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCurrencyByIdCommandHandlerBase : CommandBase<DeleteCurrencyByIdCommand, CurrencyEntity>, IRequestHandler<DeleteCurrencyByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteCurrencyByIdCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCurrencyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null || entity.IsDeleted == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}