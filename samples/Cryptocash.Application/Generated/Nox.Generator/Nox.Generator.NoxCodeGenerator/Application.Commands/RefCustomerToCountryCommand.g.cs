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
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public abstract record RefCustomerToCountryCommand(CustomerKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCustomerToCountryCommand(CustomerKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCustomerToCountryCommand(EntityKeyDto);

internal partial class CreateRefCustomerToCountryCommandHandler
	: RefCustomerToCountryCommandHandlerBase<CreateRefCustomerToCountryCommand>
{
	public CreateRefCustomerToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCustomerToCountryCommand request)
    {
		var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCountry(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefCustomerToCountryCommand(CustomerKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCustomerToCountryCommand(EntityKeyDto);

internal partial class DeleteRefCustomerToCountryCommandHandler
	: RefCustomerToCountryCommandHandlerBase<DeleteRefCustomerToCountryCommand>
{
	public DeleteRefCustomerToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCustomerToCountryCommand request)
    {
        var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCountry(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCustomerToCountryCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToCountryCommand(EntityKeyDto);

internal partial class DeleteAllRefCustomerToCountryCommandHandler
	: RefCustomerToCountryCommandHandlerBase<DeleteAllRefCustomerToCountryCommand>
{
	public DeleteAllRefCustomerToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCustomerToCountryCommand request)
    {
        var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCountry();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCustomerToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToCountryCommand
{
	public AppDbContext DbContext { get; }

	public RefCustomerToCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<CustomerEntity?> GetCustomer(CustomerKeyDto entityKeyDto)
	{
		var keyId = Dto.CustomerMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Customers.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Country?> GetCountry(CountryKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.CountryMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Countries.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CustomerEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}