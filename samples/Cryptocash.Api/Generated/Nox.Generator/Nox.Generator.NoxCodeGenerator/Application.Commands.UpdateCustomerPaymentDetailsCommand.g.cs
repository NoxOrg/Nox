﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CustomerPaymentDetails = Cryptocash.Domain.CustomerPaymentDetails;

namespace Cryptocash.Application.Commands;

public record UpdateCustomerPaymentDetailsCommand(System.Int64 keyId, CustomerPaymentDetailsUpdateDto EntityDto) : IRequest<CustomerPaymentDetailsKeyDto?>;

public class UpdateCustomerPaymentDetailsCommandHandler: CommandBase<UpdateCustomerPaymentDetailsCommand, CustomerPaymentDetails>, IRequestHandler<UpdateCustomerPaymentDetailsCommand, CustomerPaymentDetailsKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CustomerPaymentDetails> EntityMapper { get; }

	public UpdateCustomerPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CustomerPaymentDetails> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<CustomerPaymentDetailsKeyDto?> Handle(UpdateCustomerPaymentDetailsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CustomerPaymentDetails,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.CustomerPaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<CustomerPaymentDetails>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new CustomerPaymentDetailsKeyDto(entity.Id.Value);
	}
}