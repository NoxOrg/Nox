// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public record DeleteThirdTestEntityZeroOrOneByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteThirdTestEntityZeroOrOneByIdCommandHandler : DeleteThirdTestEntityZeroOrOneByIdCommandHandlerBase
{
	public DeleteThirdTestEntityZeroOrOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteThirdTestEntityZeroOrOneByIdCommandHandlerBase : CommandBase<DeleteThirdTestEntityZeroOrOneByIdCommand, ThirdTestEntityZeroOrOneEntity>, IRequestHandler<DeleteThirdTestEntityZeroOrOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteThirdTestEntityZeroOrOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteThirdTestEntityZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.ThirdTestEntityZeroOrOnes.FindAsync(keyId);
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