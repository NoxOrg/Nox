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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;
using PaymentProvider = CryptocashApi.Domain.PaymentProvider;

namespace CryptocashApi.Application.Commands;
public record CreatePaymentProviderCommand(PaymentProviderCreateDto EntityDto) : IRequest<PaymentProviderKeyDto>;

public partial class CreatePaymentProviderCommandHandler: CommandBase<CreatePaymentProviderCommand,PaymentProvider>, IRequestHandler <CreatePaymentProviderCommand, PaymentProviderKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<PaymentProviderCreateDto,PaymentProvider> EntityFactory { get; }

	public CreatePaymentProviderCommandHandler(
		CryptocashApiDbContext dbContext,
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