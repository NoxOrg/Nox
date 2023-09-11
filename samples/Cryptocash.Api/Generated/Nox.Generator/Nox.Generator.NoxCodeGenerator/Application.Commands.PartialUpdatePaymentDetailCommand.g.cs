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
using PaymentDetail = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public record PartialUpdatePaymentDetailCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <PaymentDetailKeyDto?>;

public class PartialUpdatePaymentDetailCommandHandler: CommandBase<PartialUpdatePaymentDetailCommand, PaymentDetail>, IRequestHandler<PartialUpdatePaymentDetailCommand, PaymentDetailKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<PaymentDetail> EntityMapper { get; }

	public PartialUpdatePaymentDetailCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<PaymentDetail> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<PaymentDetailKeyDto?> Handle(PartialUpdatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentDetail,AutoNumber>("Id", request.keyId);

		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<PaymentDetail>(), request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new PaymentDetailKeyDto(entity.Id.Value);
	}
}