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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityZeroOrOneToOneOrManyByIdCommand(IEnumerable<TestEntityZeroOrOneToOneOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandler : DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityZeroOrOneToOneOrManyByIdCommand, TestEntityZeroOrOneToOneOrManyEntity>, IRequestHandler<DeleteTestEntityZeroOrOneToOneOrManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrOneToOneOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityZeroOrOneToOneOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityZeroOrOneToOneOrManies.FindAsync(keyId);
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