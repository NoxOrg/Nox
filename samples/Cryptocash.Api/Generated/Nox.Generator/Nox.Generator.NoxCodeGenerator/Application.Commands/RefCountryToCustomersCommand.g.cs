
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

public abstract record RefCountryToCustomersCommand(CountryKeyDto EntityKeyDto, CustomerKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefCountryToCustomersCommand(CountryKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefCountryToCustomersCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCountryToCustomersCommandHandler
	: RefCountryToCustomersCommandHandlerBase<CreateRefCountryToCustomersCommand>
{
	public CreateRefCountryToCustomersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToCustomersCommand(CountryKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefCountryToCustomersCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCountryToCustomersCommandHandler
	: RefCountryToCustomersCommandHandlerBase<DeleteRefCountryToCustomersCommand>
{
	public DeleteRefCountryToCustomersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCountryToCustomersCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToCustomersCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCountryToCustomersCommandHandler
	: RefCountryToCustomersCommandHandlerBase<DeleteAllRefCountryToCustomersCommand>
{
	public DeleteAllRefCountryToCustomersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCountryToCustomersCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCustomersCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCountryToCustomersCommandHandlerBase(
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
				entity.CreateRefToCustomers(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCustomers(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.Customers).LoadAsync();
				entity.DeleteAllRefToCustomers();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}