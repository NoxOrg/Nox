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
using Store = SampleWebApp.Domain.Store;

namespace SampleWebApp.Application.Commands;

public record UpdateStoreCommand(System.String keyId, StoreUpdateDto EntityDto, System.Guid? Etag) : IRequest<StoreKeyDto?>;

public class UpdateStoreCommandHandler: CommandBase<UpdateStoreCommand, Store>, IRequestHandler<UpdateStoreCommand, StoreKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<Store> EntityMapper { get; }

	public UpdateStoreCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Store> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<StoreKeyDto?> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,Text>("Id", request.keyId);
	
		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<Store>(), request.EntityDto);
		entity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new StoreKeyDto(entity.Id.Value);
	}
}