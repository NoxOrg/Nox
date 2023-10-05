// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public record DeleteCountryByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteCountryByIdCommandHandler : DeleteCountryByIdCommandHandlerBase
{
	public DeleteCountryByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCountryByIdCommandHandlerBase : CommandBase<DeleteCountryByIdCommand, CountryEntity>, IRequestHandler<DeleteCountryByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteCountryByIdCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.keyId);

		var entity = await DbContext.Countries.FindAsync(keyId);
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