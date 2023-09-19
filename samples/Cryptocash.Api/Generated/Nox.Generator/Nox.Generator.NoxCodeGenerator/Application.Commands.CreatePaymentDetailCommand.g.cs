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
using PaymentDetail = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public record CreatePaymentDetailCommand(PaymentDetailCreateDto EntityDto) : IRequest<PaymentDetailKeyDto>;

public partial class CreatePaymentDetailCommandHandler: CreatePaymentDetailCommandHandlerBase
{
	public CreatePaymentDetailCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Customer,CustomerCreateDto> customerfactory,
        IEntityFactory<PaymentProvider,PaymentProviderCreateDto> paymentproviderfactory,
        IEntityFactory<PaymentDetail,PaymentDetailCreateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,customerfactory,paymentproviderfactory,entityFactory, serviceProvider)
	{
	}
}


public abstract class CreatePaymentDetailCommandHandlerBase: CommandBase<CreatePaymentDetailCommand,PaymentDetail>, IRequestHandler <CreatePaymentDetailCommand, PaymentDetailKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<PaymentDetail,PaymentDetailCreateDto> _entityFactory;
    private readonly IEntityFactory<Customer,CustomerCreateDto> _customerfactory;
    private readonly IEntityFactory<PaymentProvider,PaymentProviderCreateDto> _paymentproviderfactory;

	public CreatePaymentDetailCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Customer,CustomerCreateDto> customerfactory,
        IEntityFactory<PaymentProvider,PaymentProviderCreateDto> paymentproviderfactory,
        IEntityFactory<PaymentDetail,PaymentDetailCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;        
        _customerfactory = customerfactory;        
        _paymentproviderfactory = paymentproviderfactory;
	}

	public virtual async Task<PaymentDetailKeyDto> Handle(CreatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.PaymentDetailsUsedByCustomer is not null)
		{ 
			var relatedEntity = _customerfactory.CreateEntity(request.EntityDto.PaymentDetailsUsedByCustomer);
			entityToCreate.CreateRefToPaymentDetailsUsedByCustomer(relatedEntity);
		}
		if(request.EntityDto.PaymentDetailsRelatedPaymentProvider is not null)
		{ 
			var relatedEntity = _paymentproviderfactory.CreateEntity(request.EntityDto.PaymentDetailsRelatedPaymentProvider);
			entityToCreate.CreateRefToPaymentDetailsRelatedPaymentProvider(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.PaymentDetails.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new PaymentDetailKeyDto(entityToCreate.Id.Value);
	}
}