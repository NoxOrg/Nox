
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

public abstract record RefPaymentDetailToPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto, PaymentProviderKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefPaymentDetailToPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto, PaymentProviderKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToPaymentProviderCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefPaymentDetailToPaymentProviderCommandHandler
	: RefPaymentDetailToPaymentProviderCommandHandlerBase<CreateRefPaymentDetailToPaymentProviderCommand>
{
	public CreateRefPaymentDetailToPaymentProviderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefPaymentDetailToPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto, PaymentProviderKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToPaymentProviderCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefPaymentDetailToPaymentProviderCommandHandler
	: RefPaymentDetailToPaymentProviderCommandHandlerBase<DeleteRefPaymentDetailToPaymentProviderCommand>
{
	public DeleteRefPaymentDetailToPaymentProviderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefPaymentDetailToPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto)
	: RefPaymentDetailToPaymentProviderCommand(EntityKeyDto, null);

internal partial class DeleteAllRefPaymentDetailToPaymentProviderCommandHandler
	: RefPaymentDetailToPaymentProviderCommandHandlerBase<DeleteAllRefPaymentDetailToPaymentProviderCommand>
{
	public DeleteAllRefPaymentDetailToPaymentProviderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefPaymentDetailToPaymentProviderCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentDetailEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentDetailToPaymentProviderCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefPaymentDetailToPaymentProviderCommandHandlerBase(
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

		Cryptocash.Domain.PaymentProvider? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.PaymentProviderMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.PaymentProviders.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToPaymentProvider(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToPaymentProvider(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToPaymentProvider();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}