﻿﻿// Generated

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

public record UpdateStoreCommand(System.UInt32 keyId, StoreUpdateDto EntityDto) : IRequest<StoreKeyDto?>;

public class UpdateStoreCommandHandler: CommandBase<UpdateStoreCommand, Store>, IRequestHandler<UpdateStoreCommand, StoreKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<Store> EntityMapper { get; }
	public IEntityMapper<EmailAddress> EmailAddressEntityMapper { get; }

	public UpdateStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,	
			IEntityMapper<EmailAddress> entityMapperEmailAddress,
		IEntityMapper<Store> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;	
		EmailAddressEntityMapper = entityMapperEmailAddress;
		EntityMapper = entityMapper;
	}
	
	public async Task<StoreKeyDto?> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,Nuid>("Id", request.keyId);
	
		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<Store>(), request.EntityDto); 

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new StoreKeyDto(entity.Id.Value);
	} 
}