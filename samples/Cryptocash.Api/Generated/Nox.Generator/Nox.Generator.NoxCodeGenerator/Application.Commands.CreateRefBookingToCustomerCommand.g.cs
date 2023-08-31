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
public record CreateRefBookingToCustomerCommand(BookingKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefBookingToCustomerCommandHandler: CommandBase<CreateRefBookingToCustomerCommand, Booking>, 
	IRequestHandler <CreateRefBookingToCustomerCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefBookingToCustomerCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefBookingToCustomerCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Booking,DatabaseGuid>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Customer,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.Customers.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.Customer = relatedEntity;
		

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}