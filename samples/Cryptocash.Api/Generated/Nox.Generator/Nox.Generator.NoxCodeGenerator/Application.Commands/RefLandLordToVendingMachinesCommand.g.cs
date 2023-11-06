
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

public abstract record RefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefLandLordToVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefLandLordToVendingMachinesCommandHandler
	: RefLandLordToVendingMachinesCommandHandlerBase<CreateRefLandLordToVendingMachinesCommand>
{
	public CreateRefLandLordToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefLandLordToVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefLandLordToVendingMachinesCommandHandler
	: RefLandLordToVendingMachinesCommandHandlerBase<DeleteRefLandLordToVendingMachinesCommand>
{
	public DeleteRefLandLordToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto)
	: RefLandLordToVendingMachinesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefLandLordToVendingMachinesCommandHandler
	: RefLandLordToVendingMachinesCommandHandlerBase<DeleteAllRefLandLordToVendingMachinesCommand>
{
	public DeleteAllRefLandLordToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefLandLordToVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, LandLordEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefLandLordToVendingMachinesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefLandLordToVendingMachinesCommandHandlerBase(
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
				entity.CreateRefToVendingMachines(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToVendingMachines(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
				entity.DeleteAllRefToVendingMachines();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}