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

namespace SampleWebApp.Application.Commands;

public record PartialUpdateStoreCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <StoreKeyDto?>;

public class PartialUpdateStoreCommandHandler: CommandBase<PartialUpdateStoreCommand, Store>, IRequestHandler<PartialUpdateStoreCommand, StoreKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<Store> EntityMapper { get; }

	public PartialUpdateStoreCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Store> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<StoreKeyDto?> Handle(PartialUpdateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,Text>("Id", request.keyId);

		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Store>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreKeyDto(entity.Id.Value);
	}
}