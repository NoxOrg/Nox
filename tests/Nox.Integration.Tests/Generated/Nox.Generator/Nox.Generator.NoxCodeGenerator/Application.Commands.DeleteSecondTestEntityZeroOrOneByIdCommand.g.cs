// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using SecondTestEntityZeroOrOne = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public record DeleteSecondTestEntityZeroOrOneByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteSecondTestEntityZeroOrOneByIdCommandHandler:DeleteSecondTestEntityZeroOrOneByIdCommandHandlerBase
{
	public DeleteSecondTestEntityZeroOrOneByIdCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution): base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityZeroOrOneByIdCommandHandlerBase: CommandBase<DeleteSecondTestEntityZeroOrOneByIdCommand,SecondTestEntityZeroOrOne>, IRequestHandler<DeleteSecondTestEntityZeroOrOneByIdCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteSecondTestEntityZeroOrOneByIdCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityZeroOrOnes.FindAsync(keyId);
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