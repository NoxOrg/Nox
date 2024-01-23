// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using ReferenceNumberEntityEntity = ClientApi.Domain.ReferenceNumberEntity;

namespace ClientApi.Application.Commands;

public partial record DeleteReferenceNumberEntityByIdCommand(IEnumerable<ReferenceNumberEntityKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteReferenceNumberEntityByIdCommandHandler : DeleteReferenceNumberEntityByIdCommandHandlerBase
{
	public DeleteReferenceNumberEntityByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteReferenceNumberEntityByIdCommandHandlerBase : CommandCollectionBase<DeleteReferenceNumberEntityByIdCommand, ReferenceNumberEntityEntity>, IRequestHandler<DeleteReferenceNumberEntityByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteReferenceNumberEntityByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteReferenceNumberEntityByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<ReferenceNumberEntityEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.ReferenceNumberEntityMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<ReferenceNumberEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("ReferenceNumberEntity",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<ReferenceNumberEntityEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}