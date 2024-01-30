// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using PersonEntity = ClientApi.Domain.Person;

namespace ClientApi.Application.Commands;

public partial record PartialUpdatePersonCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <PersonKeyDto>;

internal partial class PartialUpdatePersonCommandHandler : PartialUpdatePersonCommandHandlerBase
{
	public PartialUpdatePersonCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdatePersonCommandHandlerBase : CommandBase<PartialUpdatePersonCommand, PersonEntity>, IRequestHandler<PartialUpdatePersonCommand, PersonKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> EntityFactory { get; }
	
	public PartialUpdatePersonCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<PersonKeyDto> Handle(PartialUpdatePersonCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.PersonMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Person>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Person",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new PersonKeyDto(entity.Id.Value);
	}
}