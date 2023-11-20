﻿
﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using EmailAddressEntity = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Commands;
public partial record UpdateEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, EmailAddressUpsertDto EntityDto, System.Guid? Etag) : IRequest <EmailAddressKeyDto?>;


internal partial class UpdateEmailAddressForStoreCommandHandler : UpdateEmailAddressForStoreCommandHandlerBase
{
	public UpdateEmailAddressForStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateEmailAddressForStoreCommandHandlerBase : CommandBase<UpdateEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler <UpdateEmailAddressForStoreCommand, EmailAddressKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> _entityFactory;

	public UpdateEmailAddressForStoreCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EmailAddressKeyDto?> Handle(UpdateEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Stores.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var entity = parentEntity.EmailAddress;
		
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, DefaultCultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmailAddressKeyDto();
	}
}