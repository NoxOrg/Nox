﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;
using StoreSecurityPasswords = SampleWebApp.Domain.StoreSecurityPasswords;

namespace SampleWebApp.Application.Commands;

public record UpdateStoreSecurityPasswordsCommand(System.String keyId, StoreSecurityPasswordsUpdateDto EntityDto, System.Guid? Etag) : IRequest<StoreSecurityPasswordsKeyDto?>;

public class UpdateStoreSecurityPasswordsCommandHandler: CommandBase<UpdateStoreSecurityPasswordsCommand, StoreSecurityPasswords>, IRequestHandler<UpdateStoreSecurityPasswordsCommand, StoreSecurityPasswordsKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<StoreSecurityPasswords> EntityMapper { get; }

	public UpdateStoreSecurityPasswordsCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<StoreSecurityPasswords> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<StoreSecurityPasswordsKeyDto?> Handle(UpdateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.keyId);
	
		var entity = await DbContext.StoreSecurityPasswords.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<StoreSecurityPasswords>(), request.EntityDto);
		entity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new StoreSecurityPasswordsKeyDto(entity.Id.Value);
	}
}