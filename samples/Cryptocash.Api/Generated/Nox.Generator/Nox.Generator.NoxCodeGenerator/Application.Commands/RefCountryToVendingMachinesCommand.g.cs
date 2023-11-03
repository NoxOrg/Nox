
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
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public abstract record RefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCountryToVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCountryToVendingMachinesCommandHandler
	: RefCountryToVendingMachinesCommandHandlerBase<CreateRefCountryToVendingMachinesCommand>
{
	public CreateRefCountryToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCountryToVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCountryToVendingMachinesCommandHandler
	: RefCountryToVendingMachinesCommandHandlerBase<DeleteRefCountryToVendingMachinesCommand>
{
	public DeleteRefCountryToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToVendingMachinesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCountryToVendingMachinesCommandHandler
	: RefCountryToVendingMachinesCommandHandlerBase<DeleteAllRefCountryToVendingMachinesCommand>
{
	public DeleteAllRefCountryToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCountryToVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToVendingMachinesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCountryToVendingMachinesCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Countries.FindAsync(keyId);
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