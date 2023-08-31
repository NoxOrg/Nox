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
using PaymentProvider = CryptocashApi.Domain.PaymentProvider;

namespace CryptocashApi.Application.Commands;

public record PartialUpdatePaymentProviderCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <PaymentProviderKeyDto?>;

public class PartialUpdatePaymentProviderCommandHandler: CommandBase<PartialUpdatePaymentProviderCommand, PaymentProvider>, IRequestHandler<PartialUpdatePaymentProviderCommand, PaymentProviderKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<PaymentProvider> EntityMapper { get; }

	public PartialUpdatePaymentProviderCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<PaymentProvider> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<PaymentProviderKeyDto?> Handle(PartialUpdatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentProvider,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<PaymentProvider>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new PaymentProviderKeyDto(entity.Id.Value);
	}
}