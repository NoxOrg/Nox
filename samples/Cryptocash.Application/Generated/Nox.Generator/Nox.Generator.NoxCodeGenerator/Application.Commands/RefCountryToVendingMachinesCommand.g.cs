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

public abstract record RefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCountryToVendingMachinesCommand(CountryKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCountryToVendingMachinesCommand(EntityKeyDto);

internal partial class CreateRefCountryToVendingMachinesCommandHandler
	: RefCountryToVendingMachinesCommandHandlerBase<CreateRefCountryToVendingMachinesCommand>
{
	public CreateRefCountryToVendingMachinesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCountryToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountryUsedByVendingMachines(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToVendingMachines(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCountryToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.VendingMachine>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCountryUsedByVendingMachines(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("VendingMachine", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToVendingMachines(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCountryToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountryUsedByVendingMachines(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToVendingMachines(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCountryToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToVendingMachines();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCountryToVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToVendingMachinesCommand
{
	public IRepository Repository { get; }

	public RefCountryToVendingMachinesCommandHandlerBase(
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
		return await Repository.FindAndIncludeAsync<Cryptocash.Domain.Country>(keys.ToArray(), x => x.VendingMachines, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.VendingMachine?> GetCountryUsedByVendingMachines(VendingMachineKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.VendingMachineMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Cryptocash.Domain.VendingMachine>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CountryEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}