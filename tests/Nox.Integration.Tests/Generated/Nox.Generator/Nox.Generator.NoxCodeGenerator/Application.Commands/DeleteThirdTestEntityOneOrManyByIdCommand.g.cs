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
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteThirdTestEntityOneOrManyByIdCommand(IEnumerable<ThirdTestEntityOneOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteThirdTestEntityOneOrManyByIdCommandHandler : DeleteThirdTestEntityOneOrManyByIdCommandHandlerBase
{
	public DeleteThirdTestEntityOneOrManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteThirdTestEntityOneOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteThirdTestEntityOneOrManyByIdCommand, ThirdTestEntityOneOrManyEntity>, IRequestHandler<DeleteThirdTestEntityOneOrManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteThirdTestEntityOneOrManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteThirdTestEntityOneOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<ThirdTestEntityOneOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.ThirdTestEntityOneOrManies.FindAsync(keyId);
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