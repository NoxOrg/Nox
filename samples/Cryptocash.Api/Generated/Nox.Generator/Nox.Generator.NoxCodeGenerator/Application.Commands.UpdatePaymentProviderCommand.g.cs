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
using PaymentProvider = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public record UpdatePaymentProviderCommand(System.Int64 keyId, PaymentProviderUpdateDto EntityDto, System.Guid? Etag) : IRequest<PaymentProviderKeyDto?>;

internal partial class UpdatePaymentProviderCommandHandler: UpdatePaymentProviderCommandHandlerBase
{
	public UpdatePaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

internal abstract class UpdatePaymentProviderCommandHandlerBase: CommandBase<UpdatePaymentProviderCommand, PaymentProvider>, IRequestHandler<UpdatePaymentProviderCommand, PaymentProviderKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> _entityFactory;

	public UpdatePaymentProviderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
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

		_entityFactory.UpdateEntity(entity, request.EntityDto);
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