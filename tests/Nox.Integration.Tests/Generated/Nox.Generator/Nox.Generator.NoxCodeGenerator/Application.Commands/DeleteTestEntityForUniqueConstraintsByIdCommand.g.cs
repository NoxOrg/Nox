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

internal partial class DeleteTestEntityForUniqueConstraintsByIdCommandHandler : DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase
{
	public DeleteTestEntityForUniqueConstraintsByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityForUniqueConstraintsByIdCommand, TestEntityForUniqueConstraintsEntity>, IRequestHandler<DeleteTestEntityForUniqueConstraintsByIdCommand, bool>
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
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityForUniqueConstraintsEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityForUniqueConstraints.FindAsync(keyId);
			if (entity == null)
			{
				return false;
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}