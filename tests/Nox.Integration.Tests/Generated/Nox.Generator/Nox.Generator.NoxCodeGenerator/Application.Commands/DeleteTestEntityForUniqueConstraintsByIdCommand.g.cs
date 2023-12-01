// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityForUniqueConstraintsByIdCommand(IEnumerable<TestEntityForUniqueConstraintsKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityForUniqueConstraintsByIdCommandHandler : DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase
{
	public DeleteTestEntityForUniqueConstraintsByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase : CommandBase<DeleteTestEntityForUniqueConstraintsByIdCommand, TestEntityForUniqueConstraintsEntity>, IRequestHandler<DeleteTestEntityForUniqueConstraintsByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityForUniqueConstraintsByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityForUniqueConstraints.FindAsync(keyId);
			if (entity == null)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;DbContext.TestEntityForUniqueConstraints.Remove(entity);
		}

		await OnCompletedAsync(request, new TestEntityForUniqueConstraintsEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}