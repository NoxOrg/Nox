﻿
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

public abstract record RefCustomerToCustomerBaseCountryCommand(CustomerKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCustomerToCustomerBaseCountryCommand(CustomerKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerBaseCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefCustomerToCustomerBaseCountryCommandHandler: RefCustomerToCustomerBaseCountryCommandHandlerBase<CreateRefCustomerToCustomerBaseCountryCommand>
{
	public CreateRefCustomerToCustomerBaseCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCustomerToCustomerBaseCountryCommand(CustomerKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerBaseCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefCustomerToCustomerBaseCountryCommandHandler: RefCustomerToCustomerBaseCountryCommandHandlerBase<DeleteRefCustomerToCustomerBaseCountryCommand>
{
	public DeleteRefCustomerToCustomerBaseCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefCustomerToCustomerBaseCountryCommandHandlerBase<TRequest>: CommandBase<TRequest, Customer>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToCustomerBaseCountryCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefCustomerToCustomerBaseCountryCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<Customer, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Country, Nox.Types.CountryCode2>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Countries.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToCustomerBaseCountry(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToCustomerBaseCountry(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}