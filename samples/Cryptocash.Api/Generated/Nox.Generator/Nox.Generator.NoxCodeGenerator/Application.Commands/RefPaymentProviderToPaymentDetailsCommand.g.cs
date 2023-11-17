
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

public abstract record RefPaymentProviderToPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefPaymentProviderToPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefPaymentProviderToPaymentDetailsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefPaymentProviderToPaymentDetailsCommandHandler
	: RefPaymentProviderToPaymentDetailsCommandHandlerBase<CreateRefPaymentProviderToPaymentDetailsCommand>
{
	public CreateRefPaymentProviderToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefPaymentProviderToPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefPaymentProviderToPaymentDetailsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefPaymentProviderToPaymentDetailsCommandHandler
	: RefPaymentProviderToPaymentDetailsCommandHandlerBase<DeleteRefPaymentProviderToPaymentDetailsCommand>
{
	public DeleteRefPaymentProviderToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefPaymentProviderToPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto)
	: RefPaymentProviderToPaymentDetailsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefPaymentProviderToPaymentDetailsCommandHandler
	: RefPaymentProviderToPaymentDetailsCommandHandlerBase<DeleteAllRefPaymentProviderToPaymentDetailsCommand>
{
	public DeleteAllRefPaymentProviderToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefPaymentProviderToPaymentDetailsCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentProviderEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentProviderToPaymentDetailsCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefPaymentProviderToPaymentDetailsCommandHandlerBase(
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
				entity.CreateRefToPaymentDetails(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToPaymentDetails(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.PaymentDetails).LoadAsync();
				entity.DeleteAllRefToPaymentDetails();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}