﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public partial record UpdatePaymentDetailCommand(System.Int64 keyId, PaymentDetailUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<PaymentDetailKeyDto>;

internal partial class UpdatePaymentDetailCommandHandler : UpdatePaymentDetailCommandHandlerBase
{
	public UpdatePaymentDetailCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdatePaymentDetailCommandHandlerBase : CommandBase<UpdatePaymentDetailCommand, PaymentDetailEntity>, IRequestHandler<UpdatePaymentDetailCommand, PaymentDetailKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> EntityFactory { get; }
	protected UpdatePaymentDetailCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<PaymentDetailKeyDto> Handle(UpdatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<Cryptocash.Domain.PaymentDetail>()
            .Where(x => x.Id == Dto.PaymentDetailMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new PaymentDetailKeyDto(entity.Id.Value);
	}
}