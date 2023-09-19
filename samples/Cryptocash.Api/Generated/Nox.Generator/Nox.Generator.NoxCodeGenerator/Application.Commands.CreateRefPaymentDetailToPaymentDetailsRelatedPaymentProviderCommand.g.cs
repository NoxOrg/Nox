
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

public record CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto, PaymentProviderKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandler: CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandlerBase
{
	public CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider)
	{ }
}

public abstract class CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandlerBase: CommandBase<CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand, PaymentDetail>, 
	IRequestHandler <CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(CreateRefPaymentDetailToPaymentDetailsRelatedPaymentProviderCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentDetail, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.PaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<PaymentProvider, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.PaymentProviders.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToPaymentProviderPaymentDetailsRelatedPaymentProvider(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}