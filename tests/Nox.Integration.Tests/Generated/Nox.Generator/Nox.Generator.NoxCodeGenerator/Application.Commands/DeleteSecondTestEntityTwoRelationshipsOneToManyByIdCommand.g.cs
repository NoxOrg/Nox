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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(IEnumerable<SecondTestEntityTwoRelationshipsOneToManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandler : DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase
{
	public DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase : CommandBase<DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand, SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
			if (entity == null)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;DbContext.SecondTestEntityTwoRelationshipsOneToManies.Remove(entity);
		}

		await OnCompletedAsync(request, new SecondTestEntityTwoRelationshipsOneToManyEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}