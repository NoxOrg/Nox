// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using CountryQualityOfLifeIndex = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public record DeleteCountryQualityOfLifeIndexByIdCommand(System.Int64 keyCountryId, System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteCountryQualityOfLifeIndexByIdCommandHandler:DeleteCountryQualityOfLifeIndexByIdCommandHandlerBase
{
	public DeleteCountryQualityOfLifeIndexByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(dbContext, noxSolution, serviceProvider)
	{
	}
}
internal abstract class DeleteCountryQualityOfLifeIndexByIdCommandHandlerBase: CommandBase<DeleteCountryQualityOfLifeIndexByIdCommand,CountryQualityOfLifeIndex>, IRequestHandler<DeleteCountryQualityOfLifeIndexByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteCountryQualityOfLifeIndexByIdCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryQualityOfLifeIndexByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyCountryId = CreateNoxTypeForKey<CountryQualityOfLifeIndex,Nox.Types.AutoNumber>("CountryId", request.keyCountryId);
		var keyId = CreateNoxTypeForKey<CountryQualityOfLifeIndex,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.CountryQualityOfLifeIndices.FindAsync(keyCountryId, keyId);
		if (entity == null)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);DbContext.CountryQualityOfLifeIndices.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}