// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public partial record DeleteWorkplaceByIdCommand(IEnumerable<WorkplaceKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteWorkplaceByIdCommandHandler : DeleteWorkplaceByIdCommandHandlerBase
{
	public DeleteWorkplaceByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteWorkplaceByIdCommandHandlerBase : CommandCollectionBase<DeleteWorkplaceByIdCommand, WorkplaceEntity>, IRequestHandler<DeleteWorkplaceByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteWorkplaceByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteWorkplaceByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<WorkplaceEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.WorkplaceMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Workplaces.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Workplace",  $"{keyId.ToString()}");
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