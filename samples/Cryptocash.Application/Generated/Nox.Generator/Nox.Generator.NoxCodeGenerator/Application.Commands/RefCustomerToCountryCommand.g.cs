// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCustomerToCountryCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomerBaseCountry(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCountry(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCustomerToCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomerBaseCountry(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCountry(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCustomerToCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCustomer(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Customer",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCountry();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCustomerToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToCountryCommand
{
	public IRepository Repository { get; }

	public RefCustomerToCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		await ExecuteAsync(request, cancellationToken);
		return true;
	}

	protected abstract Task ExecuteAsync(TRequest request, CancellationToken cancellationToken);

	protected async Task<CustomerEntity?> GetCustomer(CustomerKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CustomerMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<Customer>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Country?> GetCustomerBaseCountry(CountryKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Country>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CustomerEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}