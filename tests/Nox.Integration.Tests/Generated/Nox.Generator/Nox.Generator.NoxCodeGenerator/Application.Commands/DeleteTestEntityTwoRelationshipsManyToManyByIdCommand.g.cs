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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(IEnumerable<TestEntityTwoRelationshipsManyToManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityTwoRelationshipsManyToManyByIdCommandHandler : DeleteTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase
{
	public DeleteTestEntityTwoRelationshipsManyToManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityTwoRelationshipsManyToManyByIdCommand, TestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<DeleteTestEntityTwoRelationshipsManyToManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityTwoRelationshipsManyToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityTwoRelationshipsManyToManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
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