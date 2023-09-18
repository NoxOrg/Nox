
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
public record CreateRefVendingMachineToVendingMachineInstallationCountryCommand(VendingMachineKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefVendingMachineToVendingMachineInstallationCountryCommandHandler: CommandBase<CreateRefVendingMachineToVendingMachineInstallationCountryCommand, VendingMachine>, 
	IRequestHandler <CreateRefVendingMachineToVendingMachineInstallationCountryCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefVendingMachineToVendingMachineInstallationCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefVendingMachineToVendingMachineInstallationCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachine, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Country, Nox.Types.CountryCode2>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Countries.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToCountryVendingMachineInstallationCountry(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}