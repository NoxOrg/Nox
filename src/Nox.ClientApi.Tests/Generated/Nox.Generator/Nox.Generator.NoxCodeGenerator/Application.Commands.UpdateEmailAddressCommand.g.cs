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
public record UpdateEmailAddressCommand(StoreKeyDto ParentKeyDto, EmailAddressUpdateDto EntityDto, System.Guid? Etag) : IRequest <EmailAddressKeyDto?>;


public partial class UpdateEmailAddressCommandHandler: CommandBase<UpdateEmailAddressCommand, EmailAddress>, IRequestHandler <UpdateEmailAddressCommand, EmailAddressKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<EmailAddress> EntityMapper { get; }

	public UpdateEmailAddressCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<EmailAddress> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<EmailAddressKeyDto?> Handle(UpdateEmailAddressCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,DatabaseGuid>("Id", request.ParentKeyDto.keyId);
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

		EntityMapper.MapToEntity(entity, GetEntityDefinition<EmailAddress>(), request.EntityDto);
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