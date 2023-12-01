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
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand(IEnumerable<SecondTestEntityTwoRelationshipsOneToOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandler : DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase
{
	public DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase : CommandBase<DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand, SecondTestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler<DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.SecondTestEntityTwoRelationshipsOneToOnes.FindAsync(keyId);
			if (entity == null)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;DbContext.SecondTestEntityTwoRelationshipsOneToOnes.Remove(entity);
		}

		await OnCompletedAsync(request, new SecondTestEntityTwoRelationshipsOneToOneEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}