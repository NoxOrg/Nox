﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using PaymentProvider = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;
public record CreatePaymentProviderCommand(PaymentProviderCreateDto EntityDto) : IRequest<PaymentProviderKeyDto>;

public partial class CreatePaymentProviderCommandHandler: CommandBase<CreatePaymentProviderCommand,PaymentProvider>, IRequestHandler <CreatePaymentProviderCommand, PaymentProviderKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<PaymentProviderCreateDto,PaymentProvider> EntityFactory { get; }

	public CreatePaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<PaymentProviderCreateDto,PaymentProvider> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<PaymentProviderKeyDto> Handle(CreatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.PaymentProviders.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new PaymentProviderKeyDto(entityToCreate.Id.Value);
	}
}