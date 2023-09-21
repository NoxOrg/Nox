﻿
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;

public abstract record RefCustomerToCustomerRelatedPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCustomerToCustomerRelatedPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerRelatedPaymentDetailsCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefCustomerToCustomerRelatedPaymentDetailsCommandHandler: RefCustomerToCustomerRelatedPaymentDetailsCommandHandlerBase<CreateRefCustomerToCustomerRelatedPaymentDetailsCommand>
{
	public CreateRefCustomerToCustomerRelatedPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCustomerToCustomerRelatedPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerRelatedPaymentDetailsCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefCustomerToCustomerRelatedPaymentDetailsCommandHandler: RefCustomerToCustomerRelatedPaymentDetailsCommandHandlerBase<DeleteRefCustomerToCustomerRelatedPaymentDetailsCommand>
{
	public DeleteRefCustomerToCustomerRelatedPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefCustomerToCustomerRelatedPaymentDetailsCommandHandlerBase<TRequest>: CommandBase<TRequest, Customer>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToCustomerRelatedPaymentDetailsCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefCustomerToCustomerRelatedPaymentDetailsCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Customer, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<PaymentDetail, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.PaymentDetails.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToCustomerRelatedPaymentDetails(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToCustomerRelatedPaymentDetails(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}