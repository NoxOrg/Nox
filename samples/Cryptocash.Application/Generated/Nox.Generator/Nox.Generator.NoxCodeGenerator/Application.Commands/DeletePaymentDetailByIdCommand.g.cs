// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public partial record DeletePaymentDetailByIdCommand(IEnumerable<PaymentDetailKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeletePaymentDetailByIdCommandHandler : DeletePaymentDetailByIdCommandHandlerBase
{
	public DeletePaymentDetailByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeletePaymentDetailByIdCommandHandlerBase : CommandCollectionBase<DeletePaymentDetailByIdCommand, PaymentDetailEntity>, IRequestHandler<DeletePaymentDetailByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeletePaymentDetailByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeletePaymentDetailByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<PaymentDetailEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.PaymentDetailMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<PaymentDetailEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("PaymentDetail",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<PaymentDetailEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}