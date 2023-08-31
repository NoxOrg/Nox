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

using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
public record CreateRefStoreSecurityPasswordsToStoreCommand(StoreSecurityPasswordsKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefStoreSecurityPasswordsToStoreCommandHandler: CommandBase<CreateRefStoreSecurityPasswordsToStoreCommand, StoreSecurityPasswords>, 
	IRequestHandler <CreateRefStoreSecurityPasswordsToStoreCommand, bool>
{
	public SampleWebAppDbContext DbContext { get; }

	public CreateRefStoreSecurityPasswordsToStoreCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefStoreSecurityPasswordsToStoreCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.StoreSecurityPasswords.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Store,Text>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.Stores.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.Store = relatedEntity;
		

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}