// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public partial record DeleteCommissionByIdCommand(IEnumerable<CommissionKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCommissionByIdCommandHandler : DeleteCommissionByIdCommandHandlerBase
{
	public DeleteCommissionByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCommissionByIdCommandHandlerBase : CommandCollectionBase<DeleteCommissionByIdCommand, CommissionEntity>, IRequestHandler<DeleteCommissionByIdCommand, bool>
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
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CommissionEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Cryptocash.Domain.CommissionMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Commissions.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Commission",  $"{keyId.ToString()}");
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