﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using EmailAddressEntity = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Commands;
public record CreateEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, EmailAddressCreateDto EntityDto, System.Guid? Etag) : IRequest <EmailAddressKeyDto?>;

internal partial class CreateEmailAddressForStoreCommandHandler : CreateEmailAddressForStoreCommandHandlerBase
{
	public CreateEmailAddressForStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressCreateDto, EmailAddressUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateEmailAddressForStoreCommandHandlerBase : CommandBase<CreateEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler<CreateEmailAddressForStoreCommand, EmailAddressKeyDto?>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<EmailAddressEntity, EmailAddressCreateDto, EmailAddressUpdateDto> _entityFactory;

	public CreateEmailAddressForStoreCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressCreateDto, EmailAddressUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<EmailAddressKeyDto?> Handle(CreateEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Stores.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.VerifiedEmails = entity;
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmailAddressKeyDto();
	}
}