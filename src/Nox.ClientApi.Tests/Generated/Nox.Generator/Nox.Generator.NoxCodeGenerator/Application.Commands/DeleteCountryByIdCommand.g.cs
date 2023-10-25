// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public record DeleteCountryByIdCommand(System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteCountryByIdCommandHandler : DeleteCountryByIdCommandHandlerBase
{
	public DeleteCountryByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCountryByIdCommandHandlerBase : CommandBase<DeleteCountryByIdCommand, CountryEntity>, IRequestHandler<DeleteCountryByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCountryByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.keyId);

		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null || entity.IsDeleted == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}