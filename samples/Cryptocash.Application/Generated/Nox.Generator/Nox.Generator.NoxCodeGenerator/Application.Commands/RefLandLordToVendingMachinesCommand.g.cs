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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefLandLordToVendingMachinesCommand request)
    {
		var entity = await GetLandLord(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("LandLord",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetContractedAreasForVendingMachines(request.RelatedEntityKeyDto);
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

public partial record UpdateRefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto, List<VendingMachineKeyDto> RelatedEntitiesKeysDtos)
	: RefLandLordToVendingMachinesCommand(EntityKeyDto);

internal partial class UpdateRefLandLordToVendingMachinesCommandHandler
	: RefLandLordToVendingMachinesCommandHandlerBase<UpdateRefLandLordToVendingMachinesCommand>
{
	public UpdateRefLandLordToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefLandLordToVendingMachinesCommand request)
    {
		var entity = await GetLandLord(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("LandLord",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.VendingMachine>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetContractedAreasForVendingMachines(keyDto);
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

public record DeleteRefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefLandLordToVendingMachinesCommand(EntityKeyDto);

internal partial class DeleteRefLandLordToVendingMachinesCommandHandler
	: RefLandLordToVendingMachinesCommandHandlerBase<DeleteRefLandLordToVendingMachinesCommand>
{
	public DeleteRefLandLordToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefLandLordToVendingMachinesCommand request)
    {
        var entity = await GetLandLord(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("LandLord",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetContractedAreasForVendingMachines(request.RelatedEntityKeyDto);
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

public record DeleteAllRefLandLordToVendingMachinesCommand(LandLordKeyDto EntityKeyDto)
	: RefLandLordToVendingMachinesCommand(EntityKeyDto);

internal partial class DeleteAllRefLandLordToVendingMachinesCommandHandler
	: RefLandLordToVendingMachinesCommandHandlerBase<DeleteAllRefLandLordToVendingMachinesCommand>
{
	public DeleteAllRefLandLordToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefLandLordToVendingMachinesCommand request)
    {
        var entity = await GetLandLord(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("LandLord",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
		entity.DeleteAllRefToVendingMachines();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefLandLordToVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, LandLordEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefLandLordToVendingMachinesCommand
{
	public AppDbContext DbContext { get; }

	public RefLandLordToVendingMachinesCommandHandlerBase(
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

	protected async Task<LandLordEntity?> GetLandLord(LandLordKeyDto entityKeyDto)
	{
		var keyId = Dto.LandLordMetadata.CreateId(entityKeyDto.keyId);
		var entity = await DbContext.LandLords.FindAsync(keyId);
		if(entity is not null)
		{
			await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
		}

		return entity;
	}

	protected async Task<Cryptocash.Domain.VendingMachine?> GetContractedAreasForVendingMachines(VendingMachineKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.VendingMachineMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.VendingMachines.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, LandLordEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}