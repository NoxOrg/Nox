
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
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public abstract record RefCustomerToCustomerBaseCountryCommand(CustomerKeyDto EntityKeyDto, CountryKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCustomerToCustomerBaseCountryCommand(CustomerKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerBaseCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCustomerToCustomerBaseCountryCommandHandler
	: RefCustomerToCustomerBaseCountryCommandHandlerBase<CreateRefCustomerToCustomerBaseCountryCommand>
{
	public CreateRefCustomerToCustomerBaseCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCustomerToCustomerBaseCountryCommand(CustomerKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerBaseCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCustomerToCustomerBaseCountryCommandHandler
	: RefCustomerToCustomerBaseCountryCommandHandlerBase<DeleteRefCustomerToCustomerBaseCountryCommand>
{
	public DeleteRefCustomerToCustomerBaseCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCustomerToCustomerBaseCountryCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToCustomerBaseCountryCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCustomerToCustomerBaseCountryCommandHandler
	: RefCustomerToCustomerBaseCountryCommandHandlerBase<DeleteAllRefCustomerToCustomerBaseCountryCommand>
{
	public DeleteAllRefCustomerToCustomerBaseCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCustomerToCustomerBaseCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToCustomerBaseCountryCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCustomerToCustomerBaseCountryCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Customers.FindAsync(keyId);
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
				entity.CreateRefToCustomerBaseCountry(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCustomerBaseCountry(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCustomerBaseCountry();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}