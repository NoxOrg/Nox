﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateRefVendingMachineToBookingCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefVendingMachineToBookingCommandHandler: CommandBase<CreateRefVendingMachineToBookingCommand, VendingMachine>, 
	IRequestHandler <CreateRefVendingMachineToBookingCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefVendingMachineToBookingCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefVendingMachineToBookingCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachine,DatabaseGuid>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Booking,DatabaseGuid>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.Bookings.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}		
		entity.Bookings.Add(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}