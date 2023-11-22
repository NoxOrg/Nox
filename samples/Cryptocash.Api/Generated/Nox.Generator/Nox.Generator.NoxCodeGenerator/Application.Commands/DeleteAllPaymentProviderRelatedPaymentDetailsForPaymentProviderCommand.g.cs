﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public partial record DeleteAllPaymentProviderRelatedPaymentDetailsForPaymentProviderCommand(PaymentProviderKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllPaymentProviderRelatedPaymentDetailsForPaymentProviderCommandHandler : DeleteAllPaymentProviderRelatedPaymentDetailsForPaymentProviderCommandHandlerBase
{
	public DeleteAllPaymentProviderRelatedPaymentDetailsForPaymentProviderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllPaymentProviderRelatedPaymentDetailsForPaymentProviderCommandHandlerBase : CommandBase<DeleteAllPaymentProviderRelatedPaymentDetailsForPaymentProviderCommand, PaymentDetailEntity>, IRequestHandler <DeleteAllPaymentProviderRelatedPaymentDetailsForPaymentProviderCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllPaymentProviderRelatedPaymentDetailsForPaymentProviderCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllPaymentProviderRelatedPaymentDetailsForPaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.PaymentProviderMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.PaymentProviders.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.PaymentDetails;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.PaymentDetails.Remove(relatedEntity);
				await OnCompletedAsync(request, relatedEntity);
			}
			
			await trx.CommitAsync();
			
			var result = await DbContext.SaveChangesAsync(cancellationToken);
			if (result < 1)
			{
				return false;
			}

			return true;
		}
		catch
		{
			await trx.RollbackAsync();
			return false;
		}
	}
}