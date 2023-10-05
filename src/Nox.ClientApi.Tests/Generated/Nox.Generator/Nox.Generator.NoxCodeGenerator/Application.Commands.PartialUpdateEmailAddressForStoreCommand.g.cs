﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using EmailAddressEntity = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Commands;
public record PartialUpdateEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <EmailAddressKeyDto?>;

internal partial class PartialUpdateEmailAddressForStoreCommandHandler: PartialUpdateEmailAddressForStoreCommandHandlerBase
{
	public PartialUpdateEmailAddressForStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressCreateDto, EmailAddressUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateEmailAddressForStoreCommandHandlerBase: CommandBase<PartialUpdateEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler <PartialUpdateEmailAddressForStoreCommand, EmailAddressKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<EmailAddressEntity, EmailAddressCreateDto, EmailAddressUpdateDto> EntityFactory { get; }

	public PartialUpdateEmailAddressForStoreCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressCreateDto, EmailAddressUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<EmailAddressKeyDto?> Handle(PartialUpdateEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Stores.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var entity = parentEntity.VerifiedEmails;
		
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmailAddressKeyDto();
	}
}