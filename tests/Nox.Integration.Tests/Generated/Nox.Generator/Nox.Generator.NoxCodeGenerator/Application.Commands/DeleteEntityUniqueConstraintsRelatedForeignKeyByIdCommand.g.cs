﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Commands;

public partial record DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand(IEnumerable<EntityUniqueConstraintsRelatedForeignKeyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandler : DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandlerBase
{
	public DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandlerBase : CommandCollectionBase<DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand, EntityUniqueConstraintsRelatedForeignKeyEntity>, IRequestHandler<DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand, bool>
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
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<EntityUniqueConstraintsRelatedForeignKeyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.EntityUniqueConstraintsRelatedForeignKeys.FindAsync(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{keyId.ToString()}");
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