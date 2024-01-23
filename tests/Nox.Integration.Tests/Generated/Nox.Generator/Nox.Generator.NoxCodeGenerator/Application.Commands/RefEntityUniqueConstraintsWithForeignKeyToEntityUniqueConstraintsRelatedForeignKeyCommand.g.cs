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
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Commands;

public abstract record RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsRelatedForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityKeyDto);

internal partial class CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand>
{
	public CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand request)
    {
		var entity = await GetEntityUniqueConstraintsWithForeignKey(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetrelatestoSingleForeignKey(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToEntityUniqueConstraintsRelatedForeignKey(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsRelatedForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityKeyDto);

internal partial class DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand>
{
	public DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand request)
    {
        var entity = await GetEntityUniqueConstraintsWithForeignKey(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetrelatestoSingleForeignKey(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToEntityUniqueConstraintsRelatedForeignKey(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto)
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityKeyDto);

internal partial class DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand>
{
	public DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand request)
    {
        var entity = await GetEntityUniqueConstraintsWithForeignKey(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToEntityUniqueConstraintsRelatedForeignKey();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<TRequest> : CommandBase<TRequest, EntityUniqueConstraintsWithForeignKeyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand
{
	public AppDbContext DbContext { get; }

	public RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase(
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

	protected async Task<EntityUniqueConstraintsWithForeignKeyEntity?> GetEntityUniqueConstraintsWithForeignKey(EntityUniqueConstraintsWithForeignKeyKeyDto entityKeyDto)
	{
		var keyId = Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(entityKeyDto.keyId);		
		return await DbContext.EntityUniqueConstraintsWithForeignKeys.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey?> GetrelatestoSingleForeignKey(EntityUniqueConstraintsRelatedForeignKeyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.EntityUniqueConstraintsRelatedForeignKeys.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, EntityUniqueConstraintsWithForeignKeyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}