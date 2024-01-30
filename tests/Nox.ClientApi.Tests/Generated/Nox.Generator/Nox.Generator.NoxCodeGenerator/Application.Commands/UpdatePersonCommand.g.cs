﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using PersonEntity = ClientApi.Domain.Person;

namespace ClientApi.Application.Commands;

public partial record UpdatePersonCommand(System.Guid keyId, PersonUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<PersonKeyDto>;

internal partial class UpdatePersonCommandHandler : UpdatePersonCommandHandlerBase
{
	public UpdatePersonCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdatePersonCommandHandlerBase : CommandBase<UpdatePersonCommand, PersonEntity>, IRequestHandler<UpdatePersonCommand, PersonKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> _entityFactory;
	protected UpdatePersonCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<PersonKeyDto> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.PersonMetadata.CreateId(request.keyId);

		var entity = await DbContext.People.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Person",  $"{keyId.ToString()}");
		}
		await DbContext.Entry(entity).Reference(x => x.UserContactSelection).LoadAsync(cancellationToken);

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new PersonKeyDto(entity.Id.Value);
	}
}

public class UpdatePersonValidator : AbstractValidator<UpdatePersonCommand>
{
    public UpdatePersonValidator()
    {
    }
}