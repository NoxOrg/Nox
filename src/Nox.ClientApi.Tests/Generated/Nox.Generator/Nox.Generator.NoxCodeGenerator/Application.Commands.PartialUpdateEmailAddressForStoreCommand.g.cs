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

namespace ClientApi.Application.Commands;
public record PartialUpdateEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <EmailAddressKeyDto?>;

internal partial class PartialUpdateEmailAddressForStoreCommandHandler: PartialUpdateEmailAddressForStoreCommandHandlerBase
{
	public PartialUpdateEmailAddressForStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<EmailAddress, EmailAddressCreateDto, EmailAddressUpdateDto> entityFactory) : base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal abstract class PartialUpdateEmailAddressForStoreCommandHandlerBase: CommandBase<PartialUpdateEmailAddressForStoreCommand, EmailAddress>, IRequestHandler <PartialUpdateEmailAddressForStoreCommand, EmailAddressKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<EmailAddress, EmailAddressCreateDto, EmailAddressUpdateDto> EntityFactory { get; }

	public PartialUpdateEmailAddressForStoreCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<EmailAddress, EmailAddressCreateDto, EmailAddressUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<EmailAddressKeyDto?> Handle(PartialUpdateEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,Nox.Types.Guid>("Id", request.ParentKeyDto.keyId);

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