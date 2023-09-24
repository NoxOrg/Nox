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

public record PartialUpdatePaymentProviderCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <PaymentProviderKeyDto?>;

public class PartialUpdatePaymentProviderCommandHandler: PartialUpdatePaymentProviderCommandHandlerBase
{
	public PartialUpdatePaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
public class PartialUpdatePaymentProviderCommandHandlerBase: CommandBase<PartialUpdatePaymentProviderCommand, PaymentProvider>, IRequestHandler<PartialUpdatePaymentProviderCommand, PaymentProviderKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> EntityFactory { get; }

	public PartialUpdatePaymentProviderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<PaymentProviderKeyDto?> Handle(PartialUpdatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentProvider,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new PaymentProviderKeyDto(entity.Id.Value);
	}
}