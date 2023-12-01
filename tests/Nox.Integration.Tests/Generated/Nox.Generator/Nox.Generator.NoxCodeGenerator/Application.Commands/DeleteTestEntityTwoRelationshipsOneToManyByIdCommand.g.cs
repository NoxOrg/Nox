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
using TestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityTwoRelationshipsOneToManyByIdCommand(IEnumerable<TestEntityTwoRelationshipsOneToManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandler : DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase
{
	public DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase : CommandBase<DeleteTestEntityTwoRelationshipsOneToManyByIdCommand, TestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<DeleteTestEntityTwoRelationshipsOneToManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityTwoRelationshipsOneToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new TestEntityTwoRelationshipsOneToManyEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}