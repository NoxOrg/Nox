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
using EmailAddressEntity = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EmailAddressKeyDto>;

internal partial class PartialUpdateEmailAddressForStoreCommandHandler: PartialUpdateEmailAddressForStoreCommandHandlerBase
{
	public PartialUpdateEmailAddressForStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateEmailAddressForStoreCommandHandlerBase: CommandBase<PartialUpdateEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler <PartialUpdateEmailAddressForStoreCommand, EmailAddressKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> _entityFactory;
	
	protected PartialUpdateEmailAddressForStoreCommandHandlerBase(
		AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EmailAddressKeyDto> Handle(PartialUpdateEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.StoreMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Stores.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Store",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Reference(e => e.EmailAddress).LoadAsync(cancellationToken);
		var entity = parentEntity.EmailAddress;
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Store.EmailAddress", String.Empty);
		}

		await _entityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		_dbContext.Entry(entity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

		return new EmailAddressKeyDto();
	}
}