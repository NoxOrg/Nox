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
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public abstract record RefVendingMachineToLandLordCommand(VendingMachineKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefVendingMachineToLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToLandLordCommand(EntityKeyDto);

internal partial class CreateRefVendingMachineToLandLordCommandHandler
	: RefVendingMachineToLandLordCommandHandlerBase<CreateRefVendingMachineToLandLordCommand>
{
	public CreateRefVendingMachineToLandLordCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefVendingMachineToLandLordCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineContractedAreaLandLord(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("LandLord",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToLandLord(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefVendingMachineToLandLordCommand(VendingMachineKeyDto EntityKeyDto, LandLordKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToLandLordCommand(EntityKeyDto);

internal partial class DeleteRefVendingMachineToLandLordCommandHandler
	: RefVendingMachineToLandLordCommandHandlerBase<DeleteRefVendingMachineToLandLordCommand>
{
	public DeleteRefVendingMachineToLandLordCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefVendingMachineToLandLordCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineContractedAreaLandLord(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("LandLord", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToLandLord(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefVendingMachineToLandLordCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToLandLordCommand(EntityKeyDto);

internal partial class DeleteAllRefVendingMachineToLandLordCommandHandler
	: RefVendingMachineToLandLordCommandHandlerBase<DeleteAllRefVendingMachineToLandLordCommand>
{
	public DeleteAllRefVendingMachineToLandLordCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefVendingMachineToLandLordCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToLandLord();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefVendingMachineToLandLordCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToLandLordCommand
{
	public IRepository Repository { get; }

	public RefVendingMachineToLandLordCommandHandlerBase(
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

	protected async Task<VendingMachineEntity?> GetVendingMachine(VendingMachineKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.VendingMachineMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<VendingMachine>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.LandLord?> GetVendingMachineContractedAreaLandLord(LandLordKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.LandLordMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<LandLord>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, VendingMachineEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}