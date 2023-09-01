﻿// Generated

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
public record CreateRefCustomerPaymentDetailsToPaymentProviderCommand(CustomerPaymentDetailsKeyDto EntityKeyDto, PaymentProviderKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefCustomerPaymentDetailsToPaymentProviderCommandHandler: CommandBase<CreateRefCustomerPaymentDetailsToPaymentProviderCommand, CustomerPaymentDetails>, 
	IRequestHandler <CreateRefCustomerPaymentDetailsToPaymentProviderCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefCustomerPaymentDetailsToPaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefCustomerPaymentDetailsToPaymentProviderCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CustomerPaymentDetails,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.CustomerPaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<PaymentProvider,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.PaymentProviders.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.PaymentProvider = relatedEntity;
		

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}