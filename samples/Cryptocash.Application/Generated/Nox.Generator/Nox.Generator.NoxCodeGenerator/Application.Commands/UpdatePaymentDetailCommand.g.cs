﻿﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public partial record UpdatePaymentDetailCommand(System.Int64 keyId, PaymentDetailUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<PaymentDetailKeyDto>;

internal partial class UpdatePaymentDetailCommandHandler : UpdatePaymentDetailCommandHandlerBase
{
	public UpdatePaymentDetailCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdatePaymentDetailCommandHandlerBase : CommandBase<UpdatePaymentDetailCommand, PaymentDetailEntity>, IRequestHandler<UpdatePaymentDetailCommand, PaymentDetailKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> _entityFactory;
	protected UpdatePaymentDetailCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<PaymentDetailKeyDto> Handle(UpdatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.PaymentDetailMetadata.CreateId(request.keyId);

		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new PaymentDetailKeyDto(entity.Id.Value);
	}
}