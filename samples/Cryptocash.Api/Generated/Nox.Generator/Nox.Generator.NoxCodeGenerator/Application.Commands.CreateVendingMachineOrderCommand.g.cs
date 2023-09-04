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
using VendingMachineOrder = Cryptocash.Domain.VendingMachineOrder;

namespace Cryptocash.Application.Commands;
public record CreateVendingMachineOrderCommand(VendingMachineOrderCreateDto EntityDto) : IRequest<VendingMachineOrderKeyDto>;

public partial class CreateVendingMachineOrderCommandHandler: CommandBase<CreateVendingMachineOrderCommand,VendingMachineOrder>, IRequestHandler <CreateVendingMachineOrderCommand, VendingMachineOrderKeyDto>
{
	public CryptocashDbContext DbContext { get; }

	public CreateVendingMachineOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<VendingMachineOrderKeyDto> Handle(CreateVendingMachineOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();
	
		OnCompleted(entityToCreate);
		DbContext.VendingMachineOrders.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new VendingMachineOrderKeyDto(entityToCreate.Id.Value);
	}
}