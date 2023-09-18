
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

public record CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler: CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase
{
	public CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider)
	{ }
}

public abstract class CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase: CommandBase<CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand, PaymentProvider>, 
	IRequestHandler <CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(CreateRefPaymentProviderToPaymentProviderRelatedPaymentDetailsCommand request, CancellationToken cancellationToken)
	{
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

		entity.CreateRefToPaymentDetailPaymentProviderRelatedPaymentDetails(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}