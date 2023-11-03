
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

public abstract record RefCommissionToCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCommissionToCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCommissionToCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCommissionToCountryCommandHandler
	: RefCommissionToCountryCommandHandlerBase<CreateRefCommissionToCountryCommand>
{
	public CreateRefCommissionToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCommissionToCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCommissionToCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCommissionToCountryCommandHandler
	: RefCommissionToCountryCommandHandlerBase<DeleteRefCommissionToCountryCommand>
{
	public DeleteRefCommissionToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCommissionToCountryCommand(CommissionKeyDto EntityKeyDto)
	: RefCommissionToCountryCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCommissionToCountryCommandHandler
	: RefCommissionToCountryCommandHandlerBase<DeleteAllRefCommissionToCountryCommand>
{
	public DeleteAllRefCommissionToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCommissionToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, CommissionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCommissionToCountryCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCommissionToCountryCommandHandlerBase(
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
				entity.CreateRefToCountry(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCountry(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCountry();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}