﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateCustomerPaymentDetailsCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CustomerPaymentDetailsKeyDto?>;

public class PartialUpdateCustomerPaymentDetailsCommandHandler: CommandBase<PartialUpdateCustomerPaymentDetailsCommand>, IRequestHandler<PartialUpdateCustomerPaymentDetailsCommand, CustomerPaymentDetailsKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<CustomerPaymentDetails> EntityMapper { get; }

	public PartialUpdateCustomerPaymentDetailsCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CustomerPaymentDetails> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CustomerPaymentDetailsKeyDto?> Handle(PartialUpdateCustomerPaymentDetailsCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<CustomerPaymentDetails,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CustomerPaymentDetails.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CustomerPaymentDetails>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CustomerPaymentDetailsKeyDto(entity.Id.Value);
	}
}