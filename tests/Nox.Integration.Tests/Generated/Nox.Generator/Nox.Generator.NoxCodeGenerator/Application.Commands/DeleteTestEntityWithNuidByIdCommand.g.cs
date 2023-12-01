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
using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityWithNuidByIdCommand(IEnumerable<TestEntityWithNuidKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityWithNuidByIdCommandHandler : DeleteTestEntityWithNuidByIdCommandHandlerBase
{
	public DeleteTestEntityWithNuidByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityWithNuidByIdCommandHandlerBase : CommandBase<DeleteTestEntityWithNuidByIdCommand, TestEntityWithNuidEntity>, IRequestHandler<DeleteTestEntityWithNuidByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityWithNuidByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityWithNuidByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.TestEntityWithNuidMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityWithNuids.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new TestEntityWithNuidEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}