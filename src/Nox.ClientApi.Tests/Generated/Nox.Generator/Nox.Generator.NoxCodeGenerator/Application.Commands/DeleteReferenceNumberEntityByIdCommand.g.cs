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
using ReferenceNumberEntityEntity = ClientApi.Domain.ReferenceNumberEntity;

namespace ClientApi.Application.Commands;

public partial record DeleteReferenceNumberEntityByIdCommand(IEnumerable<ReferenceNumberEntityKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteReferenceNumberEntityByIdCommandHandler : DeleteReferenceNumberEntityByIdCommandHandlerBase
{
	public DeleteReferenceNumberEntityByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteReferenceNumberEntityByIdCommandHandlerBase : CommandCollectionBase<DeleteReferenceNumberEntityByIdCommand, ReferenceNumberEntityEntity>, IRequestHandler<DeleteReferenceNumberEntityByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteReferenceNumberEntityByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteReferenceNumberEntityByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<ReferenceNumberEntityEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = ClientApi.Domain.ReferenceNumberEntityMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.ReferenceNumberEntities.FindAsync(keyId);
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