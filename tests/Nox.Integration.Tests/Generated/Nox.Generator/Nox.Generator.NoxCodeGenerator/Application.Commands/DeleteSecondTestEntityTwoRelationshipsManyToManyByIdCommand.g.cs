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
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand(IEnumerable<SecondTestEntityTwoRelationshipsManyToManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandler : DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase
{
	public DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase : CommandBase<DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand, SecondTestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand, bool>
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
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
			if (entity == null)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;DbContext.SecondTestEntityTwoRelationshipsManyToManies.Remove(entity);
		}

		await OnCompletedAsync(request, new SecondTestEntityTwoRelationshipsManyToManyEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}