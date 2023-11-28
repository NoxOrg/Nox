// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using ForReferenceNumberEntity = TestWebApp.Domain.ForReferenceNumber;

namespace TestWebApp.Application.Commands;

public partial record DeleteForReferenceNumberByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteForReferenceNumberByIdCommandHandler : DeleteForReferenceNumberByIdCommandHandlerBase
{
	public DeleteForReferenceNumberByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteForReferenceNumberByIdCommandHandlerBase : CommandBase<DeleteForReferenceNumberByIdCommand, ForReferenceNumberEntity>, IRequestHandler<DeleteForReferenceNumberByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteForReferenceNumberByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteForReferenceNumberByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.ForReferenceNumberMetadata.CreateId(request.keyId);

		var entity = await DbContext.ForReferenceNumbers.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);DbContext.ForReferenceNumbers.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}