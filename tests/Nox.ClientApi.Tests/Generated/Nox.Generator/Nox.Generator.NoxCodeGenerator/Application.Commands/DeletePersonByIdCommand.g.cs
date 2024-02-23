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
using PersonEntity = ClientApi.Domain.Person;

namespace ClientApi.Application.Commands;

public partial record DeletePersonByIdCommand(IEnumerable<PersonKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeletePersonByIdCommandHandler : DeletePersonByIdCommandHandlerBase
{
	public DeletePersonByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeletePersonByIdCommandHandlerBase : CommandCollectionBase<DeletePersonByIdCommand, PersonEntity>, IRequestHandler<DeletePersonByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeletePersonByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<PersonEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.PersonMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<PersonEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Person",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<PersonEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}