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
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityExactlyOneToOneOrManyByIdCommand(IEnumerable<TestEntityExactlyOneToOneOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityExactlyOneToOneOrManyByIdCommandHandler : DeleteTestEntityExactlyOneToOneOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityExactlyOneToOneOrManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityExactlyOneToOneOrManyByIdCommandHandlerBase : CommandBase<DeleteTestEntityExactlyOneToOneOrManyByIdCommand, TestEntityExactlyOneToOneOrManyEntity>, IRequestHandler<DeleteTestEntityExactlyOneToOneOrManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityExactlyOneToOneOrManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityExactlyOneToOneOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityExactlyOneToOneOrManies.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new TestEntityExactlyOneToOneOrManyEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}