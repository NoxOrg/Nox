
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
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public abstract record RefCustomerToCustomerRelatedPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, PaymentDetailKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRef CustomerToCustomerRelatedPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerRelatedPaymentDetailsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCustomerToCustomerRelatedPaymentDetailsCommandHandler
	: RefCustomerToCustomerRelatedPaymentDetailsCommandHandlerBase<CreateRefCustomerToCustomerRelatedPaymentDetailsCommand>
{
	public CreateRefCustomerToCustomerRelatedPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCustomerToCustomerRelatedPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerRelatedPaymentDetailsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCustomerToCustomerRelatedPaymentDetailsCommandHandler
	: RefCustomerToCustomerRelatedPaymentDetailsCommandHandlerBase<DeleteRefCustomerToCustomerRelatedPaymentDetailsCommand>
{
	public DeleteRefCustomerToCustomerRelatedPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCustomerToCustomerRelatedPaymentDetailsCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToCustomerRelatedPaymentDetailsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCustomerToCustomerRelatedPaymentDetailsCommandHandler
	: RefCustomerToCustomerRelatedPaymentDetailsCommandHandlerBase<DeleteAllRefCustomerToCustomerRelatedPaymentDetailsCommand>
{
	public DeleteAllRefCustomerToCustomerRelatedPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCustomerToCustomerRelatedPaymentDetailsCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToCustomerRelatedPaymentDetailsCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCustomerToCustomerRelatedPaymentDetailsCommandHandlerBase(
        AppDbContext dbContext,
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
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Customers.FindAsync(keyId);
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
				entity.CreateRefToCustomerRelatedPaymentDetails(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCustomerRelatedPaymentDetails(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.CustomerRelatedPaymentDetails).LoadAsync();
				entity.DeleteAllRefToCustomerRelatedPaymentDetails();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}