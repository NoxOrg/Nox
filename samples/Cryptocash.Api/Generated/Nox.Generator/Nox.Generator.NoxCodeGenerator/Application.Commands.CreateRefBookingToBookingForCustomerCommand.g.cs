
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;
public record CreateRefBookingToBookingForCustomerCommand(BookingKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefBookingToBookingForCustomerCommandHandler: CommandBase<CreateRefBookingToBookingForCustomerCommand, Booking>, 
	IRequestHandler <CreateRefBookingToBookingForCustomerCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefBookingToBookingForCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefBookingToBookingForCustomerCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Booking, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Customer, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Customers.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToCustomerBookingForCustomer(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}