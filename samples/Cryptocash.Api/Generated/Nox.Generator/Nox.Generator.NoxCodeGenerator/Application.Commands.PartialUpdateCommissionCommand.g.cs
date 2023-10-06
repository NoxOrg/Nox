﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public record PartialUpdateCommissionCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CommissionKeyDto?>;

internal class PartialUpdateCommissionCommandHandler : PartialUpdateCommissionCommandHandlerBase
{
	public PartialUpdateCommissionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateCommissionCommandHandlerBase : CommandBase<PartialUpdateCommissionCommand, CommissionEntity>, IRequestHandler<PartialUpdateCommissionCommand, CommissionKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> EntityFactory { get; }

	public PartialUpdateCommissionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CommissionKeyDto?> Handle(PartialUpdateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CommissionMetadata.CreateId(request.keyId);

		var entity = await DbContext.Commissions.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CommissionKeyDto(entity.Id.Value);
	}
}