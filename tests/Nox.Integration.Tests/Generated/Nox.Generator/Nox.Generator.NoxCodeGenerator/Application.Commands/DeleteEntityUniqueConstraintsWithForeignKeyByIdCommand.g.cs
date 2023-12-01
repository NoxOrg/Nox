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

internal class DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandler : DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase
{
	public DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase : CommandBase<DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand, EntityUniqueConstraintsWithForeignKeyEntity>, IRequestHandler<DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand, bool>
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
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.EntityUniqueConstraintsWithForeignKeys.FindAsync(keyId);
			if (entity == null)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;DbContext.EntityUniqueConstraintsWithForeignKeys.Remove(entity);
		}

		await OnCompletedAsync(request, new EntityUniqueConstraintsWithForeignKeyEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}