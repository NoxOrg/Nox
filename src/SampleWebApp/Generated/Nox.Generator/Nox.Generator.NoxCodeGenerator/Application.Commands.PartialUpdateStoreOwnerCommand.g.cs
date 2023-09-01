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
using StoreOwner = SampleWebApp.Domain.StoreOwner;

namespace SampleWebApp.Application.Commands;

public record PartialUpdateStoreOwnerCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <StoreOwnerKeyDto?>;

public class PartialUpdateStoreOwnerCommandHandler: CommandBase<PartialUpdateStoreOwnerCommand, StoreOwner>, IRequestHandler<PartialUpdateStoreOwnerCommand, StoreOwnerKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<StoreOwner> EntityMapper { get; }

	public PartialUpdateStoreOwnerCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<StoreOwner> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<StoreOwnerKeyDto?> Handle(PartialUpdateStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<StoreOwner,Text>("Id", request.keyId);

		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<StoreOwner>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreOwnerKeyDto(entity.Id.Value);
	}
}