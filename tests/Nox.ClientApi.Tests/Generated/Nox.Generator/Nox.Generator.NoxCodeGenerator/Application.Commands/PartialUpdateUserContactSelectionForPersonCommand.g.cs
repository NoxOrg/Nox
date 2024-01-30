﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using UserContactSelectionEntity = ClientApi.Domain.UserContactSelection;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateUserContactSelectionForPersonCommand(PersonKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <UserContactSelectionKeyDto>;

internal partial class PartialUpdateUserContactSelectionForPersonCommandHandler: PartialUpdateUserContactSelectionForPersonCommandHandlerBase
{
	public PartialUpdateUserContactSelectionForPersonCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateUserContactSelectionForPersonCommandHandlerBase: CommandBase<PartialUpdateUserContactSelectionForPersonCommand, UserContactSelectionEntity>, IRequestHandler <PartialUpdateUserContactSelectionForPersonCommand, UserContactSelectionKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> _entityFactory;
	
	protected PartialUpdateUserContactSelectionForPersonCommandHandlerBase(
		AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<UserContactSelectionKeyDto> Handle(PartialUpdateUserContactSelectionForPersonCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.PersonMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.People.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Person",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Reference(e => e.UserContactSelection).LoadAsync(cancellationToken);
		var entity = parentEntity.UserContactSelection;
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Person.UserContactSelection", String.Empty);
		}

		await _entityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		_dbContext.Entry(entity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

		return new UserContactSelectionKeyDto();
	}
}