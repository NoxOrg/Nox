
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

public abstract record RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler: RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase<CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand>
{
	public CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler: RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase<DeleteRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand>
{
	public DeleteRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase<TRequest>: CommandBase<TRequest, PaymentProvider>, 
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<PaymentProvider, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
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
                entity.CreateRefToPaymentProviderRelatedPaymentDetails(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToPaymentProviderRelatedPaymentDetails(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}