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

public record UpdatePaymentDetailCommand(System.Int64 keyId, PaymentDetailUpdateDto EntityDto, System.Guid? Etag) : IRequest<PaymentDetailKeyDto?>;

public partial class UpdatePaymentDetailCommandHandler: UpdatePaymentDetailCommandHandlerBase
{
	public UpdatePaymentDetailCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

public abstract class UpdatePaymentDetailCommandHandlerBase: CommandBase<UpdatePaymentDetailCommand, PaymentDetail>, IRequestHandler<UpdatePaymentDetailCommand, PaymentDetailKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> _entityFactory;

	public UpdatePaymentDetailCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<PaymentDetailKeyDto?> Handle(UpdatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentDetail,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
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

		return new PaymentDetailKeyDto(entity.Id.Value);
	}
}