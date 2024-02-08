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
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public abstract record RefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefLandLordToVendingMachinesCommand(EntityKeyDto);

internal partial class CreateRefLandLordToVendingMachinesCommandHandler
	: RefLandLordToVendingMachinesCommandHandlerBase<CreateRefLandLordToVendingMachinesCommand>
{
	public CreateRefLandLordToVendingMachinesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefLandLordToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetLandLord(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("LandLord",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetContractedAreasForVendingMachines(request.RelatedEntityKeyDto, cancellationToken);
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

public partial record UpdateRefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto, List<VendingMachineKeyDto> RelatedEntitiesKeysDtos)
	: RefLandLordToVendingMachinesCommand(EntityKeyDto);

internal partial class UpdateRefLandLordToVendingMachinesCommandHandler
	: RefLandLordToVendingMachinesCommandHandlerBase<UpdateRefLandLordToVendingMachinesCommand>
{
	public UpdateRefLandLordToVendingMachinesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefLandLordToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetLandLord(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("LandLord",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.VendingMachine>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetContractedAreasForVendingMachines(keyDto, cancellationToken);
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

public record DeleteRefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefLandLordToVendingMachinesCommand(EntityKeyDto);

internal partial class DeleteRefLandLordToVendingMachinesCommandHandler
	: RefLandLordToVendingMachinesCommandHandlerBase<DeleteRefLandLordToVendingMachinesCommand>
{
	public DeleteRefLandLordToVendingMachinesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefLandLordToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetLandLord(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("LandLord",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetContractedAreasForVendingMachines(request.RelatedEntityKeyDto, cancellationToken);
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

public record DeleteAllRefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto)
	: RefLandLordToVendingMachinesCommand(EntityKeyDto);

internal partial class DeleteAllRefLandLordToVendingMachinesCommandHandler
	: RefLandLordToVendingMachinesCommandHandlerBase<DeleteAllRefLandLordToVendingMachinesCommand>
{
	public DeleteAllRefLandLordToVendingMachinesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefLandLordToVendingMachinesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetLandLord(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("LandLord",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToVendingMachines();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefLandLordToVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, LandLordEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefLandLordToVendingMachinesCommand
{
	public IRepository Repository { get; }

	public RefLandLordToVendingMachinesCommandHandlerBase(
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

	protected async Task<LandLordEntity?> GetLandLord(LandLordKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.LandLordMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Cryptocash.Domain.LandLord>(keys.ToArray(), x => x.VendingMachines, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.VendingMachine?> GetContractedAreasForVendingMachines(VendingMachineKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.VendingMachineMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Cryptocash.Domain.VendingMachine>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, LandLordEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}