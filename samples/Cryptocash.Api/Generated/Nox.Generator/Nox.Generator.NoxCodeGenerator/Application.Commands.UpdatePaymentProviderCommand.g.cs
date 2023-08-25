﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record UpdatePaymentProviderCommand(System.Int64 keyId, PaymentProviderUpdateDto EntityDto) : IRequest<PaymentProviderKeyDto?>;

public class UpdatePaymentProviderCommandHandler: CommandBase<UpdatePaymentProviderCommand, PaymentProvider>, IRequestHandler<UpdatePaymentProviderCommand, PaymentProviderKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<PaymentProvider> EntityMapper { get; }

	public UpdatePaymentProviderCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<PaymentProvider> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<PaymentProviderKeyDto?> Handle(UpdatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentProvider,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<PaymentProvider>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new PaymentProviderKeyDto(entity.Id.Value);
	}
}