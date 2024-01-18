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
using Nox.Exceptions;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
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
			throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await Getrelatesto2(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
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
			throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await Getrelatesto2(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("EntityUniqueConstraintsWithForeignKey", $"{keyDto.keyId.ToString()}");
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
			throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await Getrelatesto2(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("EntityUniqueConstraintsWithForeignKey", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
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
			throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
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
		var keyId = Dto.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.EntityUniqueConstraintsRelatedForeignKeys.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey?> Getrelatesto2(EntityUniqueConstraintsWithForeignKeyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.EntityUniqueConstraintsWithForeignKeys.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, EntityUniqueConstraintsRelatedForeignKeyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}