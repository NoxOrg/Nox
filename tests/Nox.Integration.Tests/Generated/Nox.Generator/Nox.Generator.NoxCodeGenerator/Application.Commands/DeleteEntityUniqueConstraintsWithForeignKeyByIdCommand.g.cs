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
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Commands;

public partial record DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand(IEnumerable<EntityUniqueConstraintsWithForeignKeyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandler : DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase
{
	public DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase : CommandCollectionBase<DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand, EntityUniqueConstraintsWithForeignKeyEntity>, IRequestHandler<DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<EntityUniqueConstraintsWithForeignKeyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.EntityUniqueConstraintsWithForeignKeys.FindAsync(keyId);
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