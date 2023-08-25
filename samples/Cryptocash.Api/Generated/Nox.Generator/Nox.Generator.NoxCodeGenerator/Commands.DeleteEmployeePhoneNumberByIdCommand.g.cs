// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Commands;

public record DeleteEmployeePhoneNumberByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteEmployeePhoneNumberByIdCommandHandler: CommandBase<DeleteEmployeePhoneNumberByIdCommand>, IRequestHandler<DeleteEmployeePhoneNumberByIdCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public DeleteEmployeePhoneNumberByIdCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteEmployeePhoneNumberByIdCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<EmployeePhoneNumber,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.EmployeePhoneNumbers.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}DbContext.EmployeePhoneNumbers.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}