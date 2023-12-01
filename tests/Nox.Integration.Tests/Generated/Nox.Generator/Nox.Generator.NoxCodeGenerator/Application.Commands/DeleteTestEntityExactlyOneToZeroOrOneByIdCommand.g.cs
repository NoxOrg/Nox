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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityExactlyOneToZeroOrOneByIdCommand(IEnumerable<TestEntityExactlyOneToZeroOrOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandler : DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandlerBase
{
	public DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandlerBase : CommandBase<DeleteTestEntityExactlyOneToZeroOrOneByIdCommand, TestEntityExactlyOneToZeroOrOneEntity>, IRequestHandler<DeleteTestEntityExactlyOneToZeroOrOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityExactlyOneToZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityExactlyOneToZeroOrOnes.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new TestEntityExactlyOneToZeroOrOneEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}