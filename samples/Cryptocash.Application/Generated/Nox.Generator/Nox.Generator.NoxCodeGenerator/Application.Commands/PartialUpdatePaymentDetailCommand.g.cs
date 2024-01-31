// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdatePaymentDetailCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <PaymentDetailKeyDto>;

internal partial class PartialUpdatePaymentDetailCommandHandler : PartialUpdatePaymentDetailCommandHandlerBase
{
	public PartialUpdatePaymentDetailCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdatePaymentDetailCommandHandlerBase : CommandBase<PartialUpdatePaymentDetailCommand, PaymentDetailEntity>, IRequestHandler<PartialUpdatePaymentDetailCommand, PaymentDetailKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> EntityFactory { get; }
	
	public PartialUpdatePaymentDetailCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<PaymentDetailKeyDto> Handle(PartialUpdatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.PaymentDetailMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<PaymentDetail>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new PaymentDetailKeyDto(entity.Id.Value);
	}
}