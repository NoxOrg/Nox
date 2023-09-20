
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

public abstract record RefCountryToCountryUsedByVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCountryToCountryUsedByVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefCountryToCountryUsedByVendingMachinesCommandHandler: RefCountryToCountryUsedByVendingMachinesCommandHandlerBase<CreateRefCountryToCountryUsedByVendingMachinesCommand>
{
	public CreateRefCountryToCountryUsedByVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToCountryUsedByVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefCountryToCountryUsedByVendingMachinesCommandHandler: RefCountryToCountryUsedByVendingMachinesCommandHandlerBase<DeleteRefCountryToCountryUsedByVendingMachinesCommand>
{
	public DeleteRefCountryToCountryUsedByVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefCountryToCountryUsedByVendingMachinesCommandHandlerBase<TRequest>: CommandBase<TRequest, Country>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCountryUsedByVendingMachinesCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefCountryToCountryUsedByVendingMachinesCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<Country, Nox.Types.CountryCode2>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Countries.FindAsync(keyId);
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
                entity.CreateRefToCountryUsedByVendingMachines(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToCountryUsedByVendingMachines(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}