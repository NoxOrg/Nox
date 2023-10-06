
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
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public abstract record RefCountryToCountryUsedByCustomersCommand(CountryKeyDto EntityKeyDto, CustomerKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCountryToCountryUsedByCustomersCommand(CountryKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByCustomersCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCountryToCountryUsedByCustomersCommandHandler
	: RefCountryToCountryUsedByCustomersCommandHandlerBase<CreateRefCountryToCountryUsedByCustomersCommand>
{
	public CreateRefCountryToCountryUsedByCustomersCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToCountryUsedByCustomersCommand(CountryKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByCustomersCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCountryToCountryUsedByCustomersCommandHandler
	: RefCountryToCountryUsedByCustomersCommandHandlerBase<DeleteRefCountryToCountryUsedByCustomersCommand>
{
	public DeleteRefCountryToCountryUsedByCustomersCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCountryToCountryUsedByCustomersCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToCountryUsedByCustomersCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCountryToCountryUsedByCustomersCommandHandler
	: RefCountryToCountryUsedByCustomersCommandHandlerBase<DeleteAllRefCountryToCountryUsedByCustomersCommand>
{
	public DeleteAllRefCountryToCountryUsedByCustomersCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCountryToCountryUsedByCustomersCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCountryUsedByCustomersCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCountryToCountryUsedByCustomersCommandHandlerBase(
		CryptocashDbContext dbContext,
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

		Cryptocash.Domain.Customer? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Customers.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToCountryUsedByCustomers(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCountryUsedByCustomers(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.CountryUsedByCustomers).LoadAsync();
				entity.DeleteAllRefToCountryUsedByCustomers();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}