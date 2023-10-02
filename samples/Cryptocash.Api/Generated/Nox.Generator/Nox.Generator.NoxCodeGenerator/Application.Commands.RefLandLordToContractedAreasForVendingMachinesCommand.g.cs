
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

public abstract record RefLandLordToContractedAreasForVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefLandLordToContractedAreasForVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefLandLordToContractedAreasForVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefLandLordToContractedAreasForVendingMachinesCommandHandler
	: RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase<CreateRefLandLordToContractedAreasForVendingMachinesCommand>
{
	public CreateRefLandLordToContractedAreasForVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefLandLordToContractedAreasForVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefLandLordToContractedAreasForVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefLandLordToContractedAreasForVendingMachinesCommandHandler
	: RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase<DeleteRefLandLordToContractedAreasForVendingMachinesCommand>
{
	public DeleteRefLandLordToContractedAreasForVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefLandLordToContractedAreasForVendingMachinesCommand(LandLordKeyDto EntityKeyDto)
	: RefLandLordToContractedAreasForVendingMachinesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefLandLordToContractedAreasForVendingMachinesCommandHandler
	: RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase<DeleteAllRefLandLordToContractedAreasForVendingMachinesCommand>
{
	public DeleteAllRefLandLordToContractedAreasForVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, LandLord>,
	IRequestHandler <TRequest, bool> where TRequest : RefLandLordToContractedAreasForVendingMachinesCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.LandLordMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.LandLords.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		VendingMachine? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToContractedAreasForVendingMachines(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToContractedAreasForVendingMachines(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.ContractedAreasForVendingMachines).LoadAsync();
				entity.DeleteAllRefToContractedAreasForVendingMachines();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}