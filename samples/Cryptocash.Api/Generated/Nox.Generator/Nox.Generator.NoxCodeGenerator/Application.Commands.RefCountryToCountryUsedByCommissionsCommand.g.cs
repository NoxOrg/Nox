
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

public abstract record RefCountryToCountryUsedByCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCountryToCountryUsedByCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByCommissionsCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefCountryToCountryUsedByCommissionsCommandHandler: RefCountryToCountryUsedByCommissionsCommandHandlerBase<CreateRefCountryToCountryUsedByCommissionsCommand>
{
	public CreateRefCountryToCountryUsedByCommissionsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToCountryUsedByCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByCommissionsCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefCountryToCountryUsedByCommissionsCommandHandler: RefCountryToCountryUsedByCommissionsCommandHandlerBase<DeleteRefCountryToCountryUsedByCommissionsCommand>
{
	public DeleteRefCountryToCountryUsedByCommissionsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefCountryToCountryUsedByCommissionsCommandHandlerBase<TRequest>: CommandBase<TRequest, Country>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCountryUsedByCommissionsCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefCountryToCountryUsedByCommissionsCommandHandlerBase(
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
		var relatedKeyId = CreateNoxTypeForKey<Commission, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Commissions.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToCountryUsedByCommissions(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToCountryUsedByCommissions(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}