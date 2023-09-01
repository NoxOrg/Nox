﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CustomerPaymentDetails = Cryptocash.Domain.CustomerPaymentDetails;

namespace Cryptocash.Application.Commands;

public record PartialUpdateCustomerPaymentDetailsCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CustomerPaymentDetailsKeyDto?>;

public class PartialUpdateCustomerPaymentDetailsCommandHandler: CommandBase<PartialUpdateCustomerPaymentDetailsCommand, CustomerPaymentDetails>, IRequestHandler<PartialUpdateCustomerPaymentDetailsCommand, CustomerPaymentDetailsKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CustomerPaymentDetails> EntityMapper { get; }

	public PartialUpdateCustomerPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CustomerPaymentDetails> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CustomerPaymentDetailsKeyDto?> Handle(PartialUpdateCustomerPaymentDetailsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CustomerPaymentDetails,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CustomerPaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CustomerPaymentDetails>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CustomerPaymentDetailsKeyDto(entity.Id.Value);
	}
}