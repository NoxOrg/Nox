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
using ThirdTestEntityZeroOrManyEntity = TestWebApp.Domain.ThirdTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteThirdTestEntityZeroOrManyByIdCommand(IEnumerable<ThirdTestEntityZeroOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteThirdTestEntityZeroOrManyByIdCommandHandler : DeleteThirdTestEntityZeroOrManyByIdCommandHandlerBase
{
	public DeleteThirdTestEntityZeroOrManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteThirdTestEntityZeroOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteThirdTestEntityZeroOrManyByIdCommand, ThirdTestEntityZeroOrManyEntity>, IRequestHandler<DeleteThirdTestEntityZeroOrManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteThirdTestEntityZeroOrManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteThirdTestEntityZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<ThirdTestEntityZeroOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.ThirdTestEntityZeroOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.ThirdTestEntityZeroOrManies.FindAsync(keyId);
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