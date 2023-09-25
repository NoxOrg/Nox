
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

public abstract record RefVendingMachineToVendingMachineContractedAreaLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefVendingMachineToVendingMachineContractedAreaLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommandHandlerBase<CreateRefVendingMachineToVendingMachineContractedAreaLandLordCommand>
{
	public CreateRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefVendingMachineToVendingMachineContractedAreaLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommandHandlerBase<DeleteRefVendingMachineToVendingMachineContractedAreaLandLordCommand>
{
	public DeleteRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefVendingMachineToVendingMachineContractedAreaLandLordCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommand(EntityKeyDto, null);

public partial class DeleteAllRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommandHandlerBase<DeleteAllRefVendingMachineToVendingMachineContractedAreaLandLordCommand>
{
	public DeleteAllRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

public abstract class RefVendingMachineToVendingMachineContractedAreaLandLordCommandHandlerBase<TRequest>: CommandBase<TRequest, VendingMachine>, 
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToVendingMachineContractedAreaLandLordCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefVendingMachineToVendingMachineContractedAreaLandLordCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<VendingMachine, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		LandLord? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<LandLord, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.LandLords.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToVendingMachineContractedAreaLandLord(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToVendingMachineContractedAreaLandLord(relatedEntity);
                break;
            case RelationshipAction.DeleteAll:
                entity.DeleteAllRefToVendingMachineContractedAreaLandLord();
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}