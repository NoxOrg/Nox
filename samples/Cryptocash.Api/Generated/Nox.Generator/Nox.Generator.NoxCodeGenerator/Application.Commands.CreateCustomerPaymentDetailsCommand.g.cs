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

namespace CryptocashApi.Application.Commands;
public record CreateCustomerPaymentDetailsCommand(CustomerPaymentDetailsCreateDto EntityDto) : IRequest<CustomerPaymentDetailsKeyDto>;

public partial class CreateCustomerPaymentDetailsCommandHandler: CommandBase<CreateCustomerPaymentDetailsCommand,CustomerPaymentDetails>, IRequestHandler <CreateCustomerPaymentDetailsCommand, CustomerPaymentDetailsKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<CustomerPaymentDetailsCreateDto,CustomerPaymentDetails> EntityFactory { get; }

	public CreateCustomerPaymentDetailsCommandHandler(
		CryptocashApiDbContext dbContext,
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