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
public record DeleteEmailAddressCommand(StoreKeyDto ParentKeyDto) : IRequest <bool>;


public partial class DeleteEmailAddressCommandHandler: CommandBase<DeleteEmailAddressCommand, EmailAddress>, IRequestHandler <DeleteEmailAddressCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteEmailAddressCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteEmailAddressCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,Nuid>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Stores.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var entity = parentEntity.EmailAddress;
		if (entity == null)
		{
			return false;
		}

		parentEntity.EmailAddress = null;
		
		OnCompleted(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		
	
		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}