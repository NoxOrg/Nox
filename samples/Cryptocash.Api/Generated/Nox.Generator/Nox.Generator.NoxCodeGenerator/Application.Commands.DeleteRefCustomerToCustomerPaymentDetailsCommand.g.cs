﻿﻿// Generated

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
public record DeleteRefCustomerToCustomerPaymentDetailsCommand(CustomerKeyDto EntityKeyDto, CustomerPaymentDetailsKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class DeleteRefCustomerToCustomerPaymentDetailsCommandHandler: CommandBase<DeleteRefCustomerToCustomerPaymentDetailsCommand, Customer>, 
	IRequestHandler <DeleteRefCustomerToCustomerPaymentDetailsCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteRefCustomerToCustomerPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteRefCustomerToCustomerPaymentDetailsCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Customer,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Customers.FindAsync(keyId);
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
		entity.CustomerPaymentDetails.Remove(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}