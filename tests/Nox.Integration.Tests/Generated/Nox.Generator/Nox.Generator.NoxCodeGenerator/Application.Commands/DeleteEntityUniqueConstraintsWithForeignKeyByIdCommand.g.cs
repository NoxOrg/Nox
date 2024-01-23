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
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Commands;

public partial record DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand(IEnumerable<EntityUniqueConstraintsWithForeignKeyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandler : DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase
{
	public DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase : CommandCollectionBase<DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand, EntityUniqueConstraintsWithForeignKeyEntity>, IRequestHandler<DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteEntityUniqueConstraintsWithForeignKeyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<EntityUniqueConstraintsWithForeignKeyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<EntityUniqueConstraintsWithForeignKey>(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<EntityUniqueConstraintsWithForeignKeyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}