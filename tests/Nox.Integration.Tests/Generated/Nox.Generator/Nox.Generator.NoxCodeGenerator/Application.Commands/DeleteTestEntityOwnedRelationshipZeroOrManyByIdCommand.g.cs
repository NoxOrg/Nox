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
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommand(IEnumerable<TestEntityOwnedRelationshipZeroOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommandHandler : DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommandHandlerBase : CommandBase<DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommand, TestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler<DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityOwnedRelationshipZeroOrManies.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new TestEntityOwnedRelationshipZeroOrManyEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}