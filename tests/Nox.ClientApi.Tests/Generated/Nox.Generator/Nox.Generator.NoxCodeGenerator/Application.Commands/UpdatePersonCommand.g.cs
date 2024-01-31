﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using PersonEntity = ClientApi.Domain.Person;

namespace ClientApi.Application.Commands;

public partial record UpdatePersonCommand(System.Guid keyId, PersonUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<PersonKeyDto>;

internal partial class UpdatePersonCommandHandler : UpdatePersonCommandHandlerBase
{
	public UpdatePersonCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdatePersonCommandHandlerBase : CommandBase<UpdatePersonCommand, PersonEntity>, IRequestHandler<UpdatePersonCommand, PersonKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> EntityFactory { get; }
	protected UpdatePersonCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<PersonKeyDto> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<Person>()
            .Where(x => x.Id == Dto.PersonMetadata.CreateId(request.keyId))
			.Include(e => e.UserContactSelection)
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Person",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new PersonKeyDto(entity.Id.Value);
	}
}

public class UpdatePersonValidator : AbstractValidator<UpdatePersonCommand>
{
    public UpdatePersonValidator()
    {
    }
}