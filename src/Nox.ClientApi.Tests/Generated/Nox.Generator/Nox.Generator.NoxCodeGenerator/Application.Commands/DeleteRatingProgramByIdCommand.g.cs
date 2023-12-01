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

internal class DeleteRatingProgramByIdCommandHandler : DeleteRatingProgramByIdCommandHandlerBase
{
	public DeleteRatingProgramByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteRatingProgramByIdCommandHandlerBase : CommandBase<DeleteRatingProgramByIdCommand, RatingProgramEntity>, IRequestHandler<DeleteRatingProgramByIdCommand, bool>
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
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyStoreId = ClientApi.Domain.RatingProgramMetadata.CreateStoreId(keyDto.keyStoreId);
			var keyId = ClientApi.Domain.RatingProgramMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.RatingPrograms.FindAsync(keyStoreId, keyId);
			if (entity == null)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;DbContext.RatingPrograms.Remove(entity);
		}

		await OnCompletedAsync(request, new RatingProgramEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}