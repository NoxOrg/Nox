﻿﻿// Generated

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
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<PaymentProviderCreateDto,PaymentProvider> _entityFactory;

	public CreatePaymentProviderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<PaymentProviderCreateDto,PaymentProvider> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public async Task<PaymentProviderKeyDto> Handle(CreatePaymentProviderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);		
	
		OnCompleted(entityToCreate);
		_dbContext.PaymentProviders.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new PaymentProviderKeyDto(entityToCreate.Id.Value);
	}
}