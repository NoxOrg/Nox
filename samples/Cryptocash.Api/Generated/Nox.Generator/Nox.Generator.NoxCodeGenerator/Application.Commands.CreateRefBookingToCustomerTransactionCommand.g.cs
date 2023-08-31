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
public record CreateRefBookingToCustomerTransactionCommand(BookingKeyDto EntityKeyDto, CustomerTransactionKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefBookingToCustomerTransactionCommandHandler: CommandBase<CreateRefBookingToCustomerTransactionCommand, Booking>, 
	IRequestHandler <CreateRefBookingToCustomerTransactionCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefBookingToCustomerTransactionCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefBookingToCustomerTransactionCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Booking,DatabaseGuid>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<CustomerTransaction,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.CustomerTransactions.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}		
		entity.CustomerTransactions.Add(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}