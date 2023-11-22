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

public partial record DeleteAllPaymentDetailsForPaymentProviderCommand(PaymentProviderKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllPaymentDetailsForPaymentProviderCommandHandler : DeleteAllPaymentDetailsForPaymentProviderCommandHandlerBase
{
	public DeleteAllPaymentDetailsForPaymentProviderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllPaymentDetailsForPaymentProviderCommandHandlerBase : CommandBase<DeleteAllPaymentDetailsForPaymentProviderCommand, PaymentDetailEntity>, IRequestHandler <DeleteAllPaymentDetailsForPaymentProviderCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllPaymentDetailsForPaymentProviderCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllPaymentDetailsForPaymentProviderCommand request, CancellationToken cancellationToken)
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
				DbContext.Entry(relatedEntity).State = EntityState.Deleted;
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