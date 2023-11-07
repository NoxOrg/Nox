
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
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public abstract record RefPaymentDetailToCustomerCommand(PaymentDetailKeyDto EntityKeyDto, CustomerKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefPaymentDetailToCustomerCommand(PaymentDetailKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToCustomerCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefPaymentDetailToCustomerCommandHandler
	: RefPaymentDetailToCustomerCommandHandlerBase<CreateRefPaymentDetailToCustomerCommand>
{
	public CreateRefPaymentDetailToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefPaymentDetailToCustomerCommand(PaymentDetailKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToCustomerCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefPaymentDetailToCustomerCommandHandler
	: RefPaymentDetailToCustomerCommandHandlerBase<DeleteRefPaymentDetailToCustomerCommand>
{
	public DeleteRefPaymentDetailToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefPaymentDetailToCustomerCommand(PaymentDetailKeyDto EntityKeyDto)
	: RefPaymentDetailToCustomerCommand(EntityKeyDto, null);

internal partial class DeleteAllRefPaymentDetailToCustomerCommandHandler
	: RefPaymentDetailToCustomerCommandHandlerBase<DeleteAllRefPaymentDetailToCustomerCommand>
{
	public DeleteAllRefPaymentDetailToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefPaymentDetailToCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentDetailEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentDetailToCustomerCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefPaymentDetailToCustomerCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.PaymentDetailMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Customer? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Customers.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToCustomer(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCustomer(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCustomer();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}