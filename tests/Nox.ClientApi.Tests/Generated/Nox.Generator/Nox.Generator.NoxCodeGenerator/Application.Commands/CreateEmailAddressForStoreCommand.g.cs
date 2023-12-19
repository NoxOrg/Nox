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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using EmailAddressEntity = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Commands;
public partial record CreateEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, EmailAddressUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EmailAddressKeyDto>;

internal partial class CreateEmailAddressForStoreCommandHandler : CreateEmailAddressForStoreCommandHandlerBase
{
	public CreateEmailAddressForStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateEmailAddressForStoreCommandHandlerBase : CommandBase<CreateEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler<CreateEmailAddressForStoreCommand, EmailAddressKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> _entityFactory;

	protected CreateEmailAddressForStoreCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<EmailAddressKeyDto?> Handle(CreateEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Stores.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Store",  $"{keyId.ToString()}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto);
		parentEntity.CreateRefToEmailAddress(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;

		var result = await _dbContext.SaveChangesAsync();

		return new EmailAddressKeyDto();
	}
}