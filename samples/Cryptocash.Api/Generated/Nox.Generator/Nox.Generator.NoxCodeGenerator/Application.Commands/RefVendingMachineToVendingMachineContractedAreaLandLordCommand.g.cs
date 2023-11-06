
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
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public abstract record RefVendingMachineToVendingMachineContractedAreaLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRef VendingMachineToVendingMachineContractedAreaLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommandHandlerBase<CreateRefVendingMachineToVendingMachineContractedAreaLandLordCommand>
{
	public CreateRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefVendingMachineToVendingMachineContractedAreaLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommandHandlerBase<DeleteRefVendingMachineToVendingMachineContractedAreaLandLordCommand>
{
	public DeleteRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefVendingMachineToVendingMachineContractedAreaLandLordCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommand(EntityKeyDto, null);

internal partial class DeleteAllRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler
	: RefVendingMachineToVendingMachineContractedAreaLandLordCommandHandlerBase<DeleteAllRefVendingMachineToVendingMachineContractedAreaLandLordCommand>
{
	public DeleteAllRefVendingMachineToVendingMachineContractedAreaLandLordCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefVendingMachineToVendingMachineContractedAreaLandLordCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToVendingMachineContractedAreaLandLordCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefVendingMachineToVendingMachineContractedAreaLandLordCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.LandLord? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.LandLordMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
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

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}