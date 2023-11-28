
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

public abstract record RefCountryToCustomersCommand(CountryKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCountryToCustomersCommand(CountryKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefCountryToCustomersCommand(EntityKeyDto);

internal partial class CreateRefCountryToCustomersCommandHandler
	: RefCountryToCustomersCommandHandlerBase<CreateRefCountryToCustomersCommand>
{
	public CreateRefCountryToCustomersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCountryToCustomersCommand request)
    {
		var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetCustomer(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToCustomers(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCountryToCustomersCommand request)
    {
		var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<Cryptocash.Domain.Customer>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCustomer(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Customers).LoadAsync();
		entity.UpdateRefToCustomers(relatedEntities);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCountryToCustomersCommand request)
    {
        var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetCustomer(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToCustomers(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCountryToCustomersCommand request)
    {
        var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.Customers).LoadAsync();
		entity.DeleteAllRefToCustomers();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCountryToCustomersCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCustomersCommand
{
	public AppDbContext DbContext { get; }

	public RefCountryToCustomersCommandHandlerBase(
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

	protected async Task<CountryEntity?> GetCountry(CountryKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Countries.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Customer?> GetCustomer(CustomerKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.CustomerMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Customers.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CountryEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}