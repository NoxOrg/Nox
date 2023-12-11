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
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOneOrManyToZeroOrManyByIdCommand(IEnumerable<TestEntityOneOrManyToZeroOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandler : DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityOneOrManyToZeroOrManyByIdCommand, TestEntityOneOrManyToZeroOrManyEntity>, IRequestHandler<DeleteTestEntityOneOrManyToZeroOrManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOneOrManyToZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityOneOrManyToZeroOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(keyId);
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