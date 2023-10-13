
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public abstract record RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler
	: RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase<CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand>
{
	public CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler
	: RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase<DeleteRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand>
{
	public DeleteRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto)
	: RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler
	: RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase<DeleteAllRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand>
{
	public DeleteAllRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentProviderEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.PaymentProviderMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.PaymentDetail? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.PaymentDetailMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.PaymentDetails.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToPaymentProviderRelatedPaymentDetails(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToPaymentProviderRelatedPaymentDetails(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.PaymentProviderRelatedPaymentDetails).LoadAsync();
				entity.DeleteAllRefToPaymentProviderRelatedPaymentDetails();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}