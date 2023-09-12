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
using PaymentProvider = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public record PartialUpdatePaymentProviderCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <PaymentProviderKeyDto?>;

public class PartialUpdatePaymentProviderCommandHandler: CommandBase<PartialUpdatePaymentProviderCommand, PaymentProvider>, IRequestHandler<PartialUpdatePaymentProviderCommand, PaymentProviderKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<PaymentProvider> EntityMapper { get; }

	public PartialUpdatePaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
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
		var keyId = CreateNoxTypeForKey<PaymentProvider,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<PaymentProvider>(), request.UpdatedProperties);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new PaymentProviderKeyDto(entity.Id.Value);
	}
}