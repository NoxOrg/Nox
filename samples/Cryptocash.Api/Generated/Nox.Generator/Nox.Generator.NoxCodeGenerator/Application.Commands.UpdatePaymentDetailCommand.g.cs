﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using PaymentDetail = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public record UpdatePaymentDetailCommand(System.Int64 keyId, PaymentDetailUpdateDto EntityDto) : IRequest<PaymentDetailKeyDto?>;

public class UpdatePaymentDetailCommandHandler: CommandBase<UpdatePaymentDetailCommand, PaymentDetail>, IRequestHandler<UpdatePaymentDetailCommand, PaymentDetailKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<PaymentDetail> EntityMapper { get; }

	public UpdatePaymentDetailCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<PaymentDetail> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<PaymentDetailKeyDto?> Handle(UpdatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentDetail,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<PaymentDetail>(), request.EntityDto);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new PaymentDetailKeyDto(entity.Id.Value);
	}
}