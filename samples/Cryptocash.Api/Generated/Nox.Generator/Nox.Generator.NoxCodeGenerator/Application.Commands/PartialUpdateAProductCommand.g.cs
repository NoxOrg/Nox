﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using AProductEntity = Cryptocash.Domain.AProduct;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateAProductCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <AProductKeyDto?>;

internal partial class PartialUpdateAProductCommandHandler : PartialUpdateAProductCommandHandlerBase
{
	public PartialUpdateAProductCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<AProductEntity, AProductCreateDto, AProductUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateAProductCommandHandlerBase : CommandBase<PartialUpdateAProductCommand, AProductEntity>, IRequestHandler<PartialUpdateAProductCommand, AProductKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<AProductEntity, AProductCreateDto, AProductUpdateDto> EntityFactory { get; }

	public PartialUpdateAProductCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<AProductEntity, AProductCreateDto, AProductUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<AProductKeyDto?> Handle(PartialUpdateAProductCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.AProductMetadata.CreateId(request.keyId);

		var entity = await DbContext.AProducts.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new AProductKeyDto(entity.Id.Value);
	}
}