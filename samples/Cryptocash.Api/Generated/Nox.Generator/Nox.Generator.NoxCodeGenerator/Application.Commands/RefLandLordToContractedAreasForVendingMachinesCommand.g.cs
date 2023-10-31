
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public abstract record RefLandLordToContractedAreasForVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefLandLordToContractedAreasForVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefLandLordToContractedAreasForVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefLandLordToContractedAreasForVendingMachinesCommandHandler
	: RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase<CreateRefLandLordToContractedAreasForVendingMachinesCommand>
{
	public CreateRefLandLordToContractedAreasForVendingMachinesCommandHandler(
        AppDbContext dbContext,
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
        AppDbContext dbContext,
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, LandLordEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefLandLordToContractedAreasForVendingMachinesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase(
        AppDbContext dbContext,
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
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.LandLordMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.LandLords.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.VendingMachine? relatedEntity = null!;
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

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}