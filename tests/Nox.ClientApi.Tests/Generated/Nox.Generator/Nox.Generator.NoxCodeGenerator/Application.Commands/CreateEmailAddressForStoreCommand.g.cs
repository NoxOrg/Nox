﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;

using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using EmailAddressEntity = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Commands;
public partial record CreateEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, EmailAddressUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EmailAddressKeyDto>;

internal partial class CreateEmailAddressForStoreCommandHandler : CreateEmailAddressForStoreCommandHandlerBase
{
	public CreateEmailAddressForStoreCommandHandler(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateEmailAddressForStoreCommandHandlerBase : CommandBase<CreateEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler<CreateEmailAddressForStoreCommand, EmailAddressKeyDto?>
{
	protected readonly Nox.Domain.IRepository Repository;
	protected readonly IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> RntityFactory;
	
	protected CreateEmailAddressForStoreCommandHandlerBase(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		RntityFactory = entityFactory;
	}

	public virtual  async Task<EmailAddressKeyDto?> Handle(CreateEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.StoreMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await Repository.FindAsync<Store> (keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Store",  $"{keyId.ToString()}");
		}

		var entity = await RntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToEmailAddress(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);		
		await Repository.SaveChangesAsync();

		return new EmailAddressKeyDto();
	}
}