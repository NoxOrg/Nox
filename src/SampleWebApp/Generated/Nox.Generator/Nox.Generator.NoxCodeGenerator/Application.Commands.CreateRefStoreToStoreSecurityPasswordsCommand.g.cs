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
public record CreateRefStoreToStoreSecurityPasswordsCommand(StoreKeyDto EntityKeyDto, StoreSecurityPasswordsKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefStoreToStoreSecurityPasswordsCommandHandler: CommandBase<CreateRefStoreToStoreSecurityPasswordsCommand, Store>, 
	IRequestHandler <CreateRefStoreToStoreSecurityPasswordsCommand, bool>
{
	public SampleWebAppDbContext DbContext { get; }

	public CreateRefStoreToStoreSecurityPasswordsCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefStoreToStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,Text>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.StoreSecurityPasswords.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.StoreSecurityPasswords = relatedEntity;
		

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}