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
using Customer = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public record CreateCustomerCommand(CustomerCreateDto EntityDto) : IRequest<CustomerKeyDto>;

public partial class CreateCustomerCommandHandler: CommandBase<CreateCustomerCommand,Customer>, IRequestHandler <CreateCustomerCommand, CustomerKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<Customer,CustomerCreateDto> _entityFactory;
    private readonly IEntityFactory<PaymentDetail,PaymentDetailCreateDto> _paymentdetailfactory;
    private readonly IEntityFactory<Booking,BookingCreateDto> _bookingfactory;
    private readonly IEntityFactory<Transaction,TransactionCreateDto> _transactionfactory;
    private readonly IEntityFactory<Country,CountryCreateDto> _countryfactory;

	public CreateCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<PaymentDetail,PaymentDetailCreateDto> paymentdetailfactory,
        IEntityFactory<Booking,BookingCreateDto> bookingfactory,
        IEntityFactory<Transaction,TransactionCreateDto> transactionfactory,
        IEntityFactory<Country,CountryCreateDto> countryfactory,
        IEntityFactory<Customer,CustomerCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;        
        _paymentdetailfactory = paymentdetailfactory;        
        _bookingfactory = bookingfactory;        
        _transactionfactory = transactionfactory;        
        _countryfactory = countryfactory;
	}

	public async Task<CustomerKeyDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.CustomerRelatedPaymentDetails)
		{
			var relatedEntity = _paymentdetailfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCustomerRelatedPaymentDetails(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CustomerRelatedBookings)
		{
			var relatedEntity = _bookingfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCustomerRelatedBookings(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CustomerRelatedTransactions)
		{
			var relatedEntity = _transactionfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCustomerRelatedTransactions(relatedEntity);
		}
		if(request.EntityDto.CustomerBaseCountry is not null)
		{ 
			var relatedEntity = _countryfactory.CreateEntity(request.EntityDto.CustomerBaseCountry);
			entityToCreate.CreateRefToCustomerBaseCountry(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.Customers.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CustomerKeyDto(entityToCreate.Id.Value);
	}
}