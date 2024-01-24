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
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public abstract record RefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCountryToVendingMachinesCommand(EntityKeyDto);

internal partial class CreateRefCountryToVendingMachinesCommandHandler
	: RefCountryToVendingMachinesCommandHandlerBase<CreateRefCountryToVendingMachinesCommand>
{
	public CreateRefCountryToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCountryToVendingMachinesCommand request)
    {
		var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountryUsedByVendingMachines(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToVendingMachines(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto, List<VendingMachineKeyDto> RelatedEntitiesKeysDtos)
	: RefCountryToVendingMachinesCommand(EntityKeyDto);

internal partial class UpdateRefCountryToVendingMachinesCommandHandler
	: RefCountryToVendingMachinesCommandHandlerBase<UpdateRefCountryToVendingMachinesCommand>
{
	public UpdateRefCountryToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCountryToVendingMachinesCommand request)
    {
		var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.VendingMachine>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCountryUsedByVendingMachines(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("VendingMachine", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
		entity.UpdateRefToVendingMachines(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCountryToVendingMachinesCommand(EntityKeyDto);

internal partial class DeleteRefCountryToVendingMachinesCommandHandler
	: RefCountryToVendingMachinesCommandHandlerBase<DeleteRefCountryToVendingMachinesCommand>
{
	public DeleteRefCountryToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCountryToVendingMachinesCommand request)
    {
        var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountryUsedByVendingMachines(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToVendingMachines(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToVendingMachinesCommand(EntityKeyDto);

internal partial class DeleteAllRefCountryToVendingMachinesCommandHandler
	: RefCountryToVendingMachinesCommandHandlerBase<DeleteAllRefCountryToVendingMachinesCommand>
{
	public DeleteAllRefCountryToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCountryToVendingMachinesCommand request)
    {
        var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
		entity.DeleteAllRefToVendingMachines();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCountryToVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToVendingMachinesCommand
{
	public AppDbContext DbContext { get; }

	public RefCountryToVendingMachinesCommandHandlerBase(
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
		var keyId = Dto.CountryMetadata.CreateId(entityKeyDto.keyId);
		var entity = await DbContext.Countries.FindAsync(keyId);
		if(entity is not null)
		{
			await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
		}

		return entity;
	}

	protected async Task<Cryptocash.Domain.VendingMachine?> GetCountryUsedByVendingMachines(VendingMachineKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.VendingMachineMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.VendingMachines.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CountryEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}