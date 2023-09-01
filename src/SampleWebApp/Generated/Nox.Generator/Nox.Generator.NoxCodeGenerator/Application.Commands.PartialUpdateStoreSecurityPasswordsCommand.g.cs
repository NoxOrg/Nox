﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;
using StoreSecurityPasswords = SampleWebApp.Domain.StoreSecurityPasswords;

namespace SampleWebApp.Application.Commands;

public record PartialUpdateStoreSecurityPasswordsCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <StoreSecurityPasswordsKeyDto?>;

public class PartialUpdateStoreSecurityPasswordsCommandHandler: CommandBase<PartialUpdateStoreSecurityPasswordsCommand, StoreSecurityPasswords>, IRequestHandler<PartialUpdateStoreSecurityPasswordsCommand, StoreSecurityPasswordsKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<StoreSecurityPasswords> EntityMapper { get; }

	public PartialUpdateStoreSecurityPasswordsCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<StoreSecurityPasswords> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<StoreSecurityPasswordsKeyDto?> Handle(PartialUpdateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.keyId);

		var entity = await DbContext.StoreSecurityPasswords.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<StoreSecurityPasswords>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreSecurityPasswordsKeyDto(entity.Id.Value);
	}
}