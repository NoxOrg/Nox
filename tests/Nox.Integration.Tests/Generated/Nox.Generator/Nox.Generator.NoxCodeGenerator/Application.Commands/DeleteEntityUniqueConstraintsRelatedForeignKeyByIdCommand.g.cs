// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Commands;

public partial record DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand(IEnumerable<EntityUniqueConstraintsRelatedForeignKeyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandler : DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandlerBase
{
	public DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandlerBase : CommandCollectionBase<DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand, EntityUniqueConstraintsRelatedForeignKeyEntity>, IRequestHandler<DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<EntityUniqueConstraintsRelatedForeignKeyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<EntityUniqueConstraintsRelatedForeignKey>(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<EntityUniqueConstraintsRelatedForeignKeyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}