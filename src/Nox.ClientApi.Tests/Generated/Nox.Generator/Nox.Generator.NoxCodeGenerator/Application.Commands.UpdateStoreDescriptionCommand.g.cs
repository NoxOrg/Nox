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
using StoreDescription = ClientApi.Domain.StoreDescription;

namespace ClientApi.Application.Commands;

public record UpdateStoreDescriptionCommand(System.Guid keyStoreId, System.Int64 keyId, StoreDescriptionUpdateDto EntityDto, System.Guid? Etag) : IRequest<StoreDescriptionKeyDto?>;

public partial class UpdateStoreDescriptionCommandHandler: UpdateStoreDescriptionCommandHandlerBase
{
	public UpdateStoreDescriptionCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<StoreDescription, StoreDescriptionCreateDto, StoreDescriptionUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

public abstract class UpdateStoreDescriptionCommandHandlerBase: CommandBase<UpdateStoreDescriptionCommand, StoreDescription>, IRequestHandler<UpdateStoreDescriptionCommand, StoreDescriptionKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<StoreDescription, StoreDescriptionCreateDto, StoreDescriptionUpdateDto> _entityFactory;

	public UpdateStoreDescriptionCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<StoreDescription, StoreDescriptionCreateDto, StoreDescriptionUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<StoreDescriptionKeyDto?> Handle(UpdateStoreDescriptionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyStoreId = CreateNoxTypeForKey<StoreDescription,Nox.Types.Guid>("StoreId", request.keyStoreId);
		var keyId = CreateNoxTypeForKey<StoreDescription,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.StoreDescriptions.FindAsync(keyStoreId, keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new StoreDescriptionKeyDto(entity.StoreId.Value, entity.Id.Value);
	}
}