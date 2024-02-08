// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public partial record DeleteVendingMachineByIdCommand(IEnumerable<VendingMachineKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteVendingMachineByIdCommandHandler : DeleteVendingMachineByIdCommandHandlerBase
{
	public DeleteVendingMachineByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteVendingMachineByIdCommandHandlerBase : CommandCollectionBase<DeleteVendingMachineByIdCommand, VendingMachineEntity>, IRequestHandler<DeleteVendingMachineByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteVendingMachineByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteVendingMachineByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<VendingMachineEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.VendingMachineMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<VendingMachineEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("VendingMachine",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<VendingMachineEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}