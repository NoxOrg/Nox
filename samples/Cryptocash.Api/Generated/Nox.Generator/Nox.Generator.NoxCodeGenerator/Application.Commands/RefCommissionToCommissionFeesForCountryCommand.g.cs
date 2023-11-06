
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
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public abstract record RefCommissionToCommissionFeesForCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRef CommissionToCommissionFeesForCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCommissionToCommissionFeesForCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCommissionToCommissionFeesForCountryCommandHandler
	: RefCommissionToCommissionFeesForCountryCommandHandlerBase<CreateRefCommissionToCommissionFeesForCountryCommand>
{
	public CreateRefCommissionToCommissionFeesForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCommissionToCommissionFeesForCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCommissionToCommissionFeesForCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCommissionToCommissionFeesForCountryCommandHandler
	: RefCommissionToCommissionFeesForCountryCommandHandlerBase<DeleteRefCommissionToCommissionFeesForCountryCommand>
{
	public DeleteRefCommissionToCommissionFeesForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCommissionToCommissionFeesForCountryCommand(CommissionKeyDto EntityKeyDto)
	: RefCommissionToCommissionFeesForCountryCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCommissionToCommissionFeesForCountryCommandHandler
	: RefCommissionToCommissionFeesForCountryCommandHandlerBase<DeleteAllRefCommissionToCommissionFeesForCountryCommand>
{
	public DeleteAllRefCommissionToCommissionFeesForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCommissionToCommissionFeesForCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, CommissionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCommissionToCommissionFeesForCountryCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCommissionToCommissionFeesForCountryCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.CommissionMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Commissions.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Country? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CountryMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
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

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}