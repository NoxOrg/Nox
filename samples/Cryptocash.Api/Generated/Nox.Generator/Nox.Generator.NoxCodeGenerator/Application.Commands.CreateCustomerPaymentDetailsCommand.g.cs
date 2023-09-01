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
using CustomerPaymentDetails = Cryptocash.Domain.CustomerPaymentDetails;

namespace Cryptocash.Application.Commands;
public record CreateCustomerPaymentDetailsCommand(CustomerPaymentDetailsCreateDto EntityDto) : IRequest<CustomerPaymentDetailsKeyDto>;

public partial class CreateCustomerPaymentDetailsCommandHandler: CommandBase<CreateCustomerPaymentDetailsCommand,CustomerPaymentDetails>, IRequestHandler <CreateCustomerPaymentDetailsCommand, CustomerPaymentDetailsKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<CustomerPaymentDetailsCreateDto,CustomerPaymentDetails> EntityFactory { get; }

	public CreateCustomerPaymentDetailsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CustomerPaymentDetailsCreateDto,CustomerPaymentDetails> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CustomerPaymentDetailsKeyDto> Handle(CreateCustomerPaymentDetailsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.CustomerPaymentDetails.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CustomerPaymentDetailsKeyDto(entityToCreate.Id.Value);
	}
}