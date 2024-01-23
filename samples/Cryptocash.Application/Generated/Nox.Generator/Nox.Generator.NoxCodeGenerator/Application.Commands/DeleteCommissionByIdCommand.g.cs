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
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public partial record DeleteCommissionByIdCommand(IEnumerable<CommissionKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCommissionByIdCommandHandler : DeleteCommissionByIdCommandHandlerBase
{
	public DeleteCommissionByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCommissionByIdCommandHandlerBase : CommandCollectionBase<DeleteCommissionByIdCommand, CommissionEntity>, IRequestHandler<DeleteCommissionByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCommissionByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCommissionByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CommissionEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.CommissionMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<Commission>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Commission",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<CommissionEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}