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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefVendingMachineToLandLordCommand request)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineContractedAreaLandLord(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("LandLord",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToLandLord(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefVendingMachineToLandLordCommand request)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineContractedAreaLandLord(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("LandLord", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToLandLord(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefVendingMachineToLandLordCommand request)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToLandLord();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefVendingMachineToLandLordCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToLandLordCommand
{
	public AppDbContext DbContext { get; }

	public RefVendingMachineToLandLordCommandHandlerBase(
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

	protected async Task<VendingMachineEntity?> GetVendingMachine(VendingMachineKeyDto entityKeyDto)
	{
		var keyId = Dto.VendingMachineMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.VendingMachines.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.LandLord?> GetVendingMachineContractedAreaLandLord(LandLordKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.LandLordMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.LandLords.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, VendingMachineEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}