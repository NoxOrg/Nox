﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Domain;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using EmailAddressEntity = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EmailAddressKeyDto>;

internal partial class PartialUpdateEmailAddressForStoreCommandHandler: PartialUpdateEmailAddressForStoreCommandHandlerBase
{
	public PartialUpdateEmailAddressForStoreCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateEmailAddressForStoreCommandHandlerBase: CommandBase<PartialUpdateEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler <PartialUpdateEmailAddressForStoreCommand, EmailAddressKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> EntityFactory;
	
	protected PartialUpdateEmailAddressForStoreCommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<EmailAddressKeyDto> Handle(PartialUpdateEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await Repository.FindAndIncludeAsync<Store>(keys.ToArray(),e => e.EmailAddress, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Store",  "keyId");
		}
		var entity = parentEntity.EmailAddress;
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Store.EmailAddress", String.Empty);
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new EmailAddressKeyDto();
	}
}