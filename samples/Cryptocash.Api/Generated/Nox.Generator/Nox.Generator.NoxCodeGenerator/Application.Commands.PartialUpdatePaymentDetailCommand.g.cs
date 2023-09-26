﻿﻿// Generated

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

internal class PartialUpdatePaymentDetailCommandHandler: PartialUpdatePaymentDetailCommandHandlerBase
{
	public PartialUpdatePaymentDetailCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal class PartialUpdatePaymentDetailCommandHandlerBase: CommandBase<PartialUpdatePaymentDetailCommand, PaymentDetail>, IRequestHandler<PartialUpdatePaymentDetailCommand, PaymentDetailKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> EntityFactory { get; }

	public PartialUpdatePaymentDetailCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<PaymentDetailKeyDto?> Handle(PartialUpdatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentDetail,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new PaymentDetailKeyDto(entity.Id.Value);
	}
}