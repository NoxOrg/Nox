
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

public abstract record RefLandLordToContractedAreasForVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefLandLordToContractedAreasForVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefLandLordToContractedAreasForVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefLandLordToContractedAreasForVendingMachinesCommandHandler: RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase<CreateRefLandLordToContractedAreasForVendingMachinesCommand>
{
	public CreateRefLandLordToContractedAreasForVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefLandLordToContractedAreasForVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefLandLordToContractedAreasForVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefLandLordToContractedAreasForVendingMachinesCommandHandler: RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase<DeleteRefLandLordToContractedAreasForVendingMachinesCommand>
{
	public DeleteRefLandLordToContractedAreasForVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase<TRequest>: CommandBase<TRequest, LandLord>, 
	IRequestHandler <TRequest, bool> where TRequest : RefLandLordToContractedAreasForVendingMachinesCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefLandLordToContractedAreasForVendingMachinesCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<LandLord, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.LandLords.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<VendingMachine, Nox.Types.Guid>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToContractedAreasForVendingMachines(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToContractedAreasForVendingMachines(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}