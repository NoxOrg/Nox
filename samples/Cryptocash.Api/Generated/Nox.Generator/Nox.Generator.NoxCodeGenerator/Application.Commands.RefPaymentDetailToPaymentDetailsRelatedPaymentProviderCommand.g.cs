
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

public abstract record RefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto, PaymentProviderKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto, PaymentProviderKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandler
	: RefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandlerBase<CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand>
{
	public CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto, PaymentProviderKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandler
	: RefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandlerBase<DeleteRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand>
{
	public DeleteRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto)
	: RefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand(EntityKeyDto, null);

internal partial class DeleteAllRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandler
	: RefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandlerBase<DeleteAllRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand>
{
	public DeleteAllRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandlerBase<TRequest>: CommandBase<TRequest, PaymentDetail>, 
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandlerBase(
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

		PaymentProvider? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<PaymentProvider, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.PaymentProviders.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToPaymentDetailsRelatedPaymentProvider(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToPaymentDetailsRelatedPaymentProvider(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToPaymentDetailsRelatedPaymentProvider();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}