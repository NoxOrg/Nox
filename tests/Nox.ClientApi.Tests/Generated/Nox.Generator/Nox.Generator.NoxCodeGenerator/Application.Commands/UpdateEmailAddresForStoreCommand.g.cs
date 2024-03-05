﻿﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using EmailAddressEntity = ClientApi.Domain.EmailAddress;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public partial record UpdateEmailAddresForStoreCommand(StoreKeyDto ParentKeyDto, EmailAddressUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EmailAddressKeyDto>;

internal partial class UpdateEmailAddresForStoreCommandHandler : UpdateEmailAddresForStoreCommandHandlerBase
{
	public UpdateEmailAddresForStoreCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateEmailAddresForStoreCommandHandlerBase : CommandBase<UpdateEmailAddresForStoreCommand, EmailAddressEntity>, IRequestHandler <UpdateEmailAddresForStoreCommand, EmailAddressKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> _entityFactory;

	protected UpdateEmailAddresForStoreCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EmailAddressKeyDto> Handle(UpdateEmailAddresForStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Store>(keys.ToArray(),e => e.EmailAddress, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Store",  "keyId");		
		var entity = parentEntity.EmailAddress;
		if (entity is null)
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		else
			await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new EmailAddressKeyDto();
	}
	
	private async Task<EmailAddressEntity> CreateEntityAsync(EmailAddressUpsertDto upsertDto, StoreEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToEmailAddress(entity);
		return entity;
	}
}