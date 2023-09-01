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
public record CreateRefPaymentProviderToCustomerPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, CustomerPaymentDetailsKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefPaymentProviderToCustomerPaymentDetailsCommandHandler: CommandBase<CreateRefPaymentProviderToCustomerPaymentDetailsCommand, PaymentProvider>, 
	IRequestHandler <CreateRefPaymentProviderToCustomerPaymentDetailsCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefPaymentProviderToCustomerPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefPaymentProviderToCustomerPaymentDetailsCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentProvider,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<CustomerPaymentDetails,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.CustomerPaymentDetails.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.CustomerPaymentDetails = relatedEntity;
		

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}