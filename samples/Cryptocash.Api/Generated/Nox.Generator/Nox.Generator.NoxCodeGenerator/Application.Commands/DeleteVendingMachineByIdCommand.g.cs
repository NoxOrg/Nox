// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public partial record DeleteVendingMachineByIdCommand(IEnumerable<VendingMachineKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteVendingMachineByIdCommandHandler : DeleteVendingMachineByIdCommandHandlerBase
{
	public DeleteVendingMachineByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteVendingMachineByIdCommandHandlerBase : CommandCollectionBase<DeleteVendingMachineByIdCommand, VendingMachineEntity>, IRequestHandler<DeleteVendingMachineByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteVendingMachineByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteVendingMachineByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<VendingMachineEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.VendingMachines.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}