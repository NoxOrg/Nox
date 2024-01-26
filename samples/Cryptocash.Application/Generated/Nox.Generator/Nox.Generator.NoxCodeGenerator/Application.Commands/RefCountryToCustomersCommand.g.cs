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
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public abstract record RefCountryToCustomersCommand(CountryKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCountryToCustomersCommand(CountryKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefCountryToCustomersCommand(EntityKeyDto);

internal partial class CreateRefCountryToCustomersCommandHandler
	: RefCountryToCustomersCommandHandlerBase<CreateRefCountryToCustomersCommand>
{
	public CreateRefCountryToCustomersCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCountryToCustomersCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountryUsedByCustomers(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Customer",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCustomers(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCountryToCustomersCommand(CountryKeyDto EntityKeyDto, List<CustomerKeyDto> RelatedEntitiesKeysDtos)
	: RefCountryToCustomersCommand(EntityKeyDto);

internal partial class UpdateRefCountryToCustomersCommandHandler
	: RefCountryToCustomersCommandHandlerBase<UpdateRefCountryToCustomersCommand>
{
	public UpdateRefCountryToCustomersCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCountryToCustomersCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.Customer>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCountryUsedByCustomers(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Customer", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToCustomers(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCountryToCustomersCommand(CountryKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefCountryToCustomersCommand(EntityKeyDto);

internal partial class DeleteRefCountryToCustomersCommandHandler
	: RefCountryToCustomersCommandHandlerBase<DeleteRefCountryToCustomersCommand>
{
	public DeleteRefCountryToCustomersCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCountryToCustomersCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountryUsedByCustomers(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Customer", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCustomers(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCountryToCustomersCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToCustomersCommand(EntityKeyDto);

internal partial class DeleteAllRefCountryToCustomersCommandHandler
	: RefCountryToCustomersCommandHandlerBase<DeleteAllRefCountryToCustomersCommand>
{
	public DeleteAllRefCountryToCustomersCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCountryToCustomersCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCustomers();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCountryToCustomersCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCustomersCommand
{
	public IRepository Repository { get; }

	public RefCountryToCustomersCommandHandlerBase(
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

	protected async Task<CountryEntity?> GetCountry(CountryKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Country>(keys.ToArray(), x => x.Customers, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Customer?> GetCountryUsedByCustomers(CustomerKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CustomerMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Customer>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CountryEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}