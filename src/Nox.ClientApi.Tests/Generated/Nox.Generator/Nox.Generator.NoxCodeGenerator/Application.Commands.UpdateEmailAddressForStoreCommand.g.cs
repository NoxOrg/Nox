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
public record UpdateEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, EmailAddressUpdateDto EntityDto, System.Guid? Etag) : IRequest <EmailAddressKeyDto?>;


internal partial class UpdateEmailAddressForStoreCommandHandler : UpdateEmailAddressForStoreCommandHandlerBase
{
	public UpdateEmailAddressForStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressCreateDto, EmailAddressUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateEmailAddressForStoreCommandHandlerBase : CommandBase<UpdateEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler <UpdateEmailAddressForStoreCommand, EmailAddressKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<EmailAddressEntity, EmailAddressCreateDto, EmailAddressUpdateDto> _entityFactory;

	public UpdateEmailAddressForStoreCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressCreateDto, EmailAddressUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EmailAddressKeyDto?> Handle(UpdateEmailAddressForStoreCommand request, CancellationToken cancellationToken)
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

		_entityFactory.UpdateEntity(entity, request.EntityDto);
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