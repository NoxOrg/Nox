
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

public abstract record RefCountryToCountryUsedByCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCountryToCountryUsedByCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByCommissionsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCountryToCountryUsedByCommissionsCommandHandler
	: RefCountryToCountryUsedByCommissionsCommandHandlerBase<CreateRefCountryToCountryUsedByCommissionsCommand>
{
	public CreateRefCountryToCountryUsedByCommissionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToCountryUsedByCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByCommissionsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCountryToCountryUsedByCommissionsCommandHandler
	: RefCountryToCountryUsedByCommissionsCommandHandlerBase<DeleteRefCountryToCountryUsedByCommissionsCommand>
{
	public DeleteRefCountryToCountryUsedByCommissionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCountryToCountryUsedByCommissionsCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToCountryUsedByCommissionsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCountryToCountryUsedByCommissionsCommandHandler
	: RefCountryToCountryUsedByCommissionsCommandHandlerBase<DeleteAllRefCountryToCountryUsedByCommissionsCommand>
{
	public DeleteAllRefCountryToCountryUsedByCommissionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCountryToCountryUsedByCommissionsCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCountryUsedByCommissionsCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCountryToCountryUsedByCommissionsCommandHandlerBase(
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
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Commission? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CommissionMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Commissions.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToCountryUsedByCommissions(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCountryUsedByCommissions(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.CountryUsedByCommissions).LoadAsync();
				entity.DeleteAllRefToCountryUsedByCommissions();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}