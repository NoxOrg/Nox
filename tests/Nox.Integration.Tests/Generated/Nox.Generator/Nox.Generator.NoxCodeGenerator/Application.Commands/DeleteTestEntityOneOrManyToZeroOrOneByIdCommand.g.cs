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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOneOrManyToZeroOrOneByIdCommand(IEnumerable<TestEntityOneOrManyToZeroOrOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityOneOrManyToZeroOrOneByIdCommandHandler : DeleteTestEntityOneOrManyToZeroOrOneByIdCommandHandlerBase
{
	public DeleteTestEntityOneOrManyToZeroOrOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOneOrManyToZeroOrOneByIdCommandHandlerBase : CommandBase<DeleteTestEntityOneOrManyToZeroOrOneByIdCommand, TestEntityOneOrManyToZeroOrOneEntity>, IRequestHandler<DeleteTestEntityOneOrManyToZeroOrOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityOneOrManyToZeroOrOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOneOrManyToZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityOneOrManyToZeroOrOnes.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new TestEntityOneOrManyToZeroOrOneEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}