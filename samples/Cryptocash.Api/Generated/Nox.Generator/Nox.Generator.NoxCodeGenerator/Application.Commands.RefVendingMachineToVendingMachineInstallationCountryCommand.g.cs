
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

public abstract record RefVendingMachineToVendingMachineInstallationCountryCommand(VendingMachineKeyDto EntityKeyDto, CountryKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefVendingMachineToVendingMachineInstallationCountryCommand(VendingMachineKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineInstallationCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefVendingMachineToVendingMachineInstallationCountryCommandHandler
	: RefVendingMachineToVendingMachineInstallationCountryCommandHandlerBase<CreateRefVendingMachineToVendingMachineInstallationCountryCommand>
{
	public CreateRefVendingMachineToVendingMachineInstallationCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefVendingMachineToVendingMachineInstallationCountryCommand(VendingMachineKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineInstallationCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefVendingMachineToVendingMachineInstallationCountryCommandHandler
	: RefVendingMachineToVendingMachineInstallationCountryCommandHandlerBase<DeleteRefVendingMachineToVendingMachineInstallationCountryCommand>
{
	public DeleteRefVendingMachineToVendingMachineInstallationCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefVendingMachineToVendingMachineInstallationCountryCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToVendingMachineInstallationCountryCommand(EntityKeyDto, null);

internal partial class DeleteAllRefVendingMachineToVendingMachineInstallationCountryCommandHandler
	: RefVendingMachineToVendingMachineInstallationCountryCommandHandlerBase<DeleteAllRefVendingMachineToVendingMachineInstallationCountryCommand>
{
	public DeleteAllRefVendingMachineToVendingMachineInstallationCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefVendingMachineToVendingMachineInstallationCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachine>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToVendingMachineInstallationCountryCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefVendingMachineToVendingMachineInstallationCountryCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Country? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CountryMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Countries.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToVendingMachineInstallationCountry(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToVendingMachineInstallationCountry(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToVendingMachineInstallationCountry();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}