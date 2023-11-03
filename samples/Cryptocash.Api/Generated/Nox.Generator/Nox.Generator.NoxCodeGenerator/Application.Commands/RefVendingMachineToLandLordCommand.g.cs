
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

public abstract record RefVendingMachineToLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefVendingMachineToLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToLandLordCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefVendingMachineToLandLordCommandHandler
	: RefVendingMachineToLandLordCommandHandlerBase<CreateRefVendingMachineToLandLordCommand>
{
	public CreateRefVendingMachineToLandLordCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefVendingMachineToLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToLandLordCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefVendingMachineToLandLordCommandHandler
	: RefVendingMachineToLandLordCommandHandlerBase<DeleteRefVendingMachineToLandLordCommand>
{
	public DeleteRefVendingMachineToLandLordCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefVendingMachineToLandLordCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToLandLordCommand(EntityKeyDto, null);

internal partial class DeleteAllRefVendingMachineToLandLordCommandHandler
	: RefVendingMachineToLandLordCommandHandlerBase<DeleteAllRefVendingMachineToLandLordCommand>
{
	public DeleteAllRefVendingMachineToLandLordCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefVendingMachineToLandLordCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToLandLordCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefVendingMachineToLandLordCommandHandlerBase(
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
				entity.CreateRefToLandLord(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToLandLord(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToLandLord();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}