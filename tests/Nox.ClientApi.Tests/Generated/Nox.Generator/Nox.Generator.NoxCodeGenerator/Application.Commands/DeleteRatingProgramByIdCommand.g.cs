// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public partial record DeleteRatingProgramByIdCommand(IEnumerable<RatingProgramKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteRatingProgramByIdCommandHandler : DeleteRatingProgramByIdCommandHandlerBase
{
	public DeleteRatingProgramByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteRatingProgramByIdCommandHandlerBase : CommandCollectionBase<DeleteRatingProgramByIdCommand, RatingProgramEntity>, IRequestHandler<DeleteRatingProgramByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteRatingProgramByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteRatingProgramByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<RatingProgramEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyStoreId = ClientApi.Domain.RatingProgramMetadata.CreateStoreId(keyDto.keyStoreId);
			var keyId = ClientApi.Domain.RatingProgramMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.RatingPrograms.FindAsync(keyStoreId, keyId);
			if (entity == null)
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