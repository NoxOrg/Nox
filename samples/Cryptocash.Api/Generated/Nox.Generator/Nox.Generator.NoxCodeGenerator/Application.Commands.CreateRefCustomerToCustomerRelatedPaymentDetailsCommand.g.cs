
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
public record CreateRefCustomerToCustomerRelatedPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefCustomerToCustomerRelatedPaymentDetailsCommandHandler: CommandBase<CreateRefCustomerToCustomerRelatedPaymentDetailsCommand, Customer>, 
	IRequestHandler <CreateRefCustomerToCustomerRelatedPaymentDetailsCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefCustomerToCustomerRelatedPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefCustomerToCustomerRelatedPaymentDetailsCommand request, CancellationToken cancellationToken)
	{
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

		entity.CreateRefToPaymentDetailCustomerRelatedPaymentDetails(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}