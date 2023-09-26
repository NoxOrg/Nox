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

public abstract record RefPaymentDetailToPaymentDetailsUsedByCustomerCommand(PaymentDetailKeyDto EntityKeyDto, CustomerKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefPaymentDetailToPaymentDetailsUsedByCustomerCommand(PaymentDetailKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToPaymentDetailsUsedByCustomerCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandler
	: RefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandlerBase<CreateRefPaymentDetailToPaymentDetailsUsedByCustomerCommand>
{
	public CreateRefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefPaymentDetailToPaymentDetailsUsedByCustomerCommand(PaymentDetailKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToPaymentDetailsUsedByCustomerCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandler
	: RefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandlerBase<DeleteRefPaymentDetailToPaymentDetailsUsedByCustomerCommand>
{
	public DeleteRefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefPaymentDetailToPaymentDetailsUsedByCustomerCommand(PaymentDetailKeyDto EntityKeyDto)
	: RefPaymentDetailToPaymentDetailsUsedByCustomerCommand(EntityKeyDto, null);

internal partial class DeleteAllRefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandler
	: RefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandlerBase<DeleteAllRefPaymentDetailToPaymentDetailsUsedByCustomerCommand>
{
	public DeleteAllRefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentDetail>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentDetailToPaymentDetailsUsedByCustomerCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefPaymentDetailToPaymentDetailsUsedByCustomerCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<PaymentDetail, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Customer? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<Customer, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Customers.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToPaymentDetailsUsedByCustomer(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToPaymentDetailsUsedByCustomer(relatedEntity);
                break;
            case RelationshipAction.DeleteAll:
                entity.DeleteAllRefToPaymentDetailsUsedByCustomer();
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}