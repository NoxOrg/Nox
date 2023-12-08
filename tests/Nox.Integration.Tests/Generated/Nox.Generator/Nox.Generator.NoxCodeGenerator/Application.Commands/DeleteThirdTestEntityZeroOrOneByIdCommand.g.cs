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
using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteThirdTestEntityZeroOrOneByIdCommand(IEnumerable<ThirdTestEntityZeroOrOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteThirdTestEntityZeroOrOneByIdCommandHandler : DeleteThirdTestEntityZeroOrOneByIdCommandHandlerBase
{
	public DeleteThirdTestEntityZeroOrOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteThirdTestEntityZeroOrOneByIdCommandHandlerBase : CommandCollectionBase<DeleteThirdTestEntityZeroOrOneByIdCommand, ThirdTestEntityZeroOrOneEntity>, IRequestHandler<DeleteThirdTestEntityZeroOrOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteThirdTestEntityZeroOrOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteThirdTestEntityZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<ThirdTestEntityZeroOrOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.ThirdTestEntityZeroOrOnes.FindAsync(keyId);
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