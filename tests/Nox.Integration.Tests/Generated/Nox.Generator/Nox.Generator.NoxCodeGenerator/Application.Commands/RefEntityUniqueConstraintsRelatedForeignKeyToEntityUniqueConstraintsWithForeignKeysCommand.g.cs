﻿
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Commands;

public abstract record RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsWithForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto);

internal partial class CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand request)
    {
		var entity = await GetEntityUniqueConstraintsRelatedForeignKey(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetEntityUniqueConstraintsWithForeignKey(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToEntityUniqueConstraintsWithForeignKeys(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto, List<EntityUniqueConstraintsWithForeignKeyKeyDto> RelatedEntitiesKeysDtos)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto);

internal partial class UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand request)
    {
		var entity = await GetEntityUniqueConstraintsRelatedForeignKey(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetEntityUniqueConstraintsWithForeignKey(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.EntityUniqueConstraintsWithForeignKeys).LoadAsync();
		entity.UpdateRefToEntityUniqueConstraintsWithForeignKeys(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsWithForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto);

internal partial class DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand request)
    {
        var entity = await GetEntityUniqueConstraintsRelatedForeignKey(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetEntityUniqueConstraintsWithForeignKey(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToEntityUniqueConstraintsWithForeignKeys(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto);

internal partial class DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand request)
    {
        var entity = await GetEntityUniqueConstraintsRelatedForeignKey(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.EntityUniqueConstraintsWithForeignKeys).LoadAsync();
		entity.DeleteAllRefToEntityUniqueConstraintsWithForeignKeys();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<TRequest> : CommandBase<TRequest, EntityUniqueConstraintsRelatedForeignKeyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand
{
	public AppDbContext DbContext { get; }

	public RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<EntityUniqueConstraintsRelatedForeignKeyEntity?> GetEntityUniqueConstraintsRelatedForeignKey(EntityUniqueConstraintsRelatedForeignKeyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.EntityUniqueConstraintsRelatedForeignKeys.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey?> GetEntityUniqueConstraintsWithForeignKey(EntityUniqueConstraintsWithForeignKeyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.EntityUniqueConstraintsWithForeignKeys.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, EntityUniqueConstraintsRelatedForeignKeyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}