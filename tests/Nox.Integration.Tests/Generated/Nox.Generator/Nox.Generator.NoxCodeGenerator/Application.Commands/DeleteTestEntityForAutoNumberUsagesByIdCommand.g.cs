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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityForAutoNumberUsagesByIdCommand(IEnumerable<TestEntityForAutoNumberUsagesKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityForAutoNumberUsagesByIdCommandHandler : DeleteTestEntityForAutoNumberUsagesByIdCommandHandlerBase
{
	public DeleteTestEntityForAutoNumberUsagesByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForAutoNumberUsagesByIdCommandHandlerBase : CommandBase<DeleteTestEntityForAutoNumberUsagesByIdCommand, TestEntityForAutoNumberUsagesEntity>, IRequestHandler<DeleteTestEntityForAutoNumberUsagesByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityForAutoNumberUsagesByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityForAutoNumberUsagesByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityForAutoNumberUsages.FindAsync(keyId);
			if (entity == null)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;DbContext.TestEntityForAutoNumberUsages.Remove(entity);
		}

		await OnCompletedAsync(request, new TestEntityForAutoNumberUsagesEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}