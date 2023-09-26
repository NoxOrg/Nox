
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

public abstract record RefCommissionToCommissionFeesForCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCommissionToCommissionFeesForCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCommissionToCommissionFeesForCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCommissionToCommissionFeesForCountryCommandHandler
	: RefCommissionToCommissionFeesForCountryCommandHandlerBase<CreateRefCommissionToCommissionFeesForCountryCommand>
{
	public CreateRefCommissionToCommissionFeesForCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCommissionToCommissionFeesForCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCommissionToCommissionFeesForCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCommissionToCommissionFeesForCountryCommandHandler
	: RefCommissionToCommissionFeesForCountryCommandHandlerBase<DeleteRefCommissionToCommissionFeesForCountryCommand>
{
	public DeleteRefCommissionToCommissionFeesForCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCommissionToCommissionFeesForCountryCommand(CommissionKeyDto EntityKeyDto)
	: RefCommissionToCommissionFeesForCountryCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCommissionToCommissionFeesForCountryCommandHandler
	: RefCommissionToCommissionFeesForCountryCommandHandlerBase<DeleteAllRefCommissionToCommissionFeesForCountryCommand>
{
	public DeleteAllRefCommissionToCommissionFeesForCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCommissionToCommissionFeesForCountryCommandHandlerBase<TRequest>: CommandBase<TRequest, Commission>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCommissionToCommissionFeesForCountryCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCommissionToCommissionFeesForCountryCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<Commission, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Commissions.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Country? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<Country, Nox.Types.CountryCode2>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Countries.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToCommissionFeesForCountry(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCommissionFeesForCountry(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCommissionFeesForCountry();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}