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
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Commands;

public partial record DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand(IEnumerable<EntityUniqueConstraintsRelatedForeignKeyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandler : DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandlerBase
{
	public DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandlerBase : CommandBase<DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand, EntityUniqueConstraintsRelatedForeignKeyEntity>, IRequestHandler<DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.EntityUniqueConstraintsRelatedForeignKeys.FindAsync(keyId);
			if (entity == null)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;DbContext.EntityUniqueConstraintsRelatedForeignKeys.Remove(entity);
		}

		await OnCompletedAsync(request, new EntityUniqueConstraintsRelatedForeignKeyEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}