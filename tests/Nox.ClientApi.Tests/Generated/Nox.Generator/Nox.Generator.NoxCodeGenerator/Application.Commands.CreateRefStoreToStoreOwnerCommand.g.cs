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

namespace ClientApi.Application.Commands;
public record CreateRefStoreToStoreOwnerCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefStoreToStoreOwnerCommandHandler: CommandBase<CreateRefStoreToStoreOwnerCommand, Store>, 
	IRequestHandler <CreateRefStoreToStoreOwnerCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public CreateRefStoreToStoreOwnerCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefStoreToStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,Nuid>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<StoreOwner,Text>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.StoreOwners.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.StoreOwner = relatedEntity;
		

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}