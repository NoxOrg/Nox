﻿﻿// Generated

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
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public record PartialUpdatePaymentDetailCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <PaymentDetailKeyDto?>;

internal class PartialUpdatePaymentDetailCommandHandler : PartialUpdatePaymentDetailCommandHandlerBase
{
	public PartialUpdatePaymentDetailCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdatePaymentDetailCommandHandlerBase : CommandBase<PartialUpdatePaymentDetailCommand, PaymentDetailEntity>, IRequestHandler<PartialUpdatePaymentDetailCommand, PaymentDetailKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> EntityFactory { get; }

	public PartialUpdatePaymentDetailCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<PaymentDetailKeyDto?> Handle(PartialUpdatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.PaymentDetailMetadata.CreateId(request.keyId);

		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new PaymentDetailKeyDto(entity.Id.Value);
	}
}