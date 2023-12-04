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
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand(IEnumerable<TestEntityOwnedRelationshipExactlyOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandler : DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandlerBase
{
	public DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand, TestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler<DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityOwnedRelationshipExactlyOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
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