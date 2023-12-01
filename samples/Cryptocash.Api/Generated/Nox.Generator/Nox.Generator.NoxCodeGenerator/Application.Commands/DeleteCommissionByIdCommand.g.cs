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
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public partial record DeleteCommissionByIdCommand(IEnumerable<CommissionKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteCommissionByIdCommandHandler : DeleteCommissionByIdCommandHandlerBase
{
	public DeleteCommissionByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCommissionByIdCommandHandlerBase : CommandBase<DeleteCommissionByIdCommand, CommissionEntity>, IRequestHandler<DeleteCommissionByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCommissionByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCommissionByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = Cryptocash.Domain.CommissionMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Commissions.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new CommissionEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}