
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

public abstract record RefCountryToCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefCountryToCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefCountryToCommissionsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCountryToCommissionsCommandHandler
	: RefCountryToCommissionsCommandHandlerBase<CreateRefCountryToCommissionsCommand>
{
	public CreateRefCountryToCommissionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefCountryToCommissionsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCountryToCommissionsCommandHandler
	: RefCountryToCommissionsCommandHandlerBase<DeleteRefCountryToCommissionsCommand>
{
	public DeleteRefCountryToCommissionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCountryToCommissionsCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToCommissionsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCountryToCommissionsCommandHandler
	: RefCountryToCommissionsCommandHandlerBase<DeleteAllRefCountryToCommissionsCommand>
{
	public DeleteAllRefCountryToCommissionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCountryToCommissionsCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCommissionsCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCountryToCommissionsCommandHandlerBase(
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
				entity.CreateRefToCommissions(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCommissions(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.Commissions).LoadAsync();
				entity.DeleteAllRefToCommissions();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}