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
using ClientEntity = ClientApi.Domain.Client;

namespace ClientApi.Application.Commands;

public partial record DeleteClientByIdCommand(IEnumerable<ClientKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteClientByIdCommandHandler : DeleteClientByIdCommandHandlerBase
{
	public DeleteClientByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteClientByIdCommandHandlerBase : CommandCollectionBase<DeleteClientByIdCommand, ClientEntity>, IRequestHandler<DeleteClientByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteClientByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteClientByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<ClientEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.ClientMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<ClientEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Client",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<ClientEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}