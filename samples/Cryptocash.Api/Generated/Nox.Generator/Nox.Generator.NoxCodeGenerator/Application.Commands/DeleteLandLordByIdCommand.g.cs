// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public partial record DeleteLandLordByIdCommand(IEnumerable<LandLordKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteLandLordByIdCommandHandler : DeleteLandLordByIdCommandHandlerBase
{
	public DeleteLandLordByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteLandLordByIdCommandHandlerBase : CommandBase<DeleteLandLordByIdCommand, LandLordEntity>, IRequestHandler<DeleteLandLordByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteLandLordByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteLandLordByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = Cryptocash.Domain.LandLordMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.LandLords.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new LandLordEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}