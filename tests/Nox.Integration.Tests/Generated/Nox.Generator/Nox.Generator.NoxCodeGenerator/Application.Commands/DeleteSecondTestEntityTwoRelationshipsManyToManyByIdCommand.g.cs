// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand(IEnumerable<SecondTestEntityTwoRelationshipsManyToManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandler : DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase
{
	public DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase : CommandCollectionBase<DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand, SecondTestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<SecondTestEntityTwoRelationshipsManyToManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{keyId.ToString()}");
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