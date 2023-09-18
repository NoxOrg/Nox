﻿﻿// Generated

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
using PaymentProvider = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public record UpdatePaymentProviderCommand(System.Int64 keyId, PaymentProviderUpdateDto EntityDto, System.Guid? Etag) : IRequest<PaymentProviderKeyDto?>;

public partial class UpdatePaymentProviderCommandHandler: UpdatePaymentProviderCommandHandlerBase
{
	public UpdatePaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<PaymentProvider> entityMapper): base(dbContext, noxSolution, serviceProvider, entityMapper)
	{
	}
}
public abstract class UpdatePaymentProviderCommandHandlerBase: CommandBase<UpdatePaymentProviderCommand, PaymentProvider>, IRequestHandler<UpdatePaymentProviderCommand, PaymentProviderKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<PaymentProvider> EntityMapper { get; }

	public UpdatePaymentProviderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<PaymentProvider> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public virtual async Task<PaymentProviderKeyDto?> Handle(UpdatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<PaymentProvider,Nox.Types.AutoNumber>("Id", request.keyId);
	
		var entity = await DbContext.PaymentProviders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<PaymentProvider>(), request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new PaymentProviderKeyDto(entity.Id.Value);
	}
}