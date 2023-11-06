
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

public abstract record RefCountryToCountryUsedByVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRef CountryToCountryUsedByVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCountryToCountryUsedByVendingMachinesCommandHandler
	: RefCountryToCountryUsedByVendingMachinesCommandHandlerBase<CreateRefCountryToCountryUsedByVendingMachinesCommand>
{
	public CreateRefCountryToCountryUsedByVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToCountryUsedByVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCountryToCountryUsedByVendingMachinesCommandHandler
	: RefCountryToCountryUsedByVendingMachinesCommandHandlerBase<DeleteRefCountryToCountryUsedByVendingMachinesCommand>
{
	public DeleteRefCountryToCountryUsedByVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCountryToCountryUsedByVendingMachinesCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToCountryUsedByVendingMachinesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCountryToCountryUsedByVendingMachinesCommandHandler
	: RefCountryToCountryUsedByVendingMachinesCommandHandlerBase<DeleteAllRefCountryToCountryUsedByVendingMachinesCommand>
{
	public DeleteAllRefCountryToCountryUsedByVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCountryToCountryUsedByVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCountryUsedByVendingMachinesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCountryToCountryUsedByVendingMachinesCommandHandlerBase(
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
				entity.CreateRefToCountryUsedByVendingMachines(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCountryUsedByVendingMachines(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.CountryUsedByVendingMachines).LoadAsync();
				entity.DeleteAllRefToCountryUsedByVendingMachines();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}