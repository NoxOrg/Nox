// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using Country = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public record DeleteCountryByIdCommand(System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteCountryByIdCommandHandler:DeleteCountryByIdCommandHandlerBase
{
	public DeleteCountryByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution): base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCountryByIdCommandHandlerBase: CommandBase<DeleteCountryByIdCommand,Country>, IRequestHandler<DeleteCountryByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteCountryByIdCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
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

		OnCompleted(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}