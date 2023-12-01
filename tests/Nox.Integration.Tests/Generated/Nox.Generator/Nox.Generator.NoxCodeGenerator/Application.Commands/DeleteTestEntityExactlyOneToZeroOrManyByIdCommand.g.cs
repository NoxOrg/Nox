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
using TestEntityExactlyOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityExactlyOneToZeroOrManyByIdCommand(IEnumerable<TestEntityExactlyOneToZeroOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityExactlyOneToZeroOrManyByIdCommandHandler : DeleteTestEntityExactlyOneToZeroOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityExactlyOneToZeroOrManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityExactlyOneToZeroOrManyByIdCommandHandlerBase : CommandBase<DeleteTestEntityExactlyOneToZeroOrManyByIdCommand, TestEntityExactlyOneToZeroOrManyEntity>, IRequestHandler<DeleteTestEntityExactlyOneToZeroOrManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityExactlyOneToZeroOrManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityExactlyOneToZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityExactlyOneToZeroOrManies.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new TestEntityExactlyOneToZeroOrManyEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}