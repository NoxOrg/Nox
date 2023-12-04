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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOneOrManyToExactlyOneByIdCommand(IEnumerable<TestEntityOneOrManyToExactlyOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityOneOrManyToExactlyOneByIdCommandHandler : DeleteTestEntityOneOrManyToExactlyOneByIdCommandHandlerBase
{
	public DeleteTestEntityOneOrManyToExactlyOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOneOrManyToExactlyOneByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityOneOrManyToExactlyOneByIdCommand, TestEntityOneOrManyToExactlyOneEntity>, IRequestHandler<DeleteTestEntityOneOrManyToExactlyOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityOneOrManyToExactlyOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOneOrManyToExactlyOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityOneOrManyToExactlyOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityOneOrManyToExactlyOnes.FindAsync(keyId);
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