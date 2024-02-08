// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record DeleteTenantByIdCommand(IEnumerable<TenantKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTenantByIdCommandHandler : DeleteTenantByIdCommandHandlerBase
{
	public DeleteTenantByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTenantByIdCommandHandlerBase : CommandCollectionBase<DeleteTenantByIdCommand, TenantEntity>, IRequestHandler<DeleteTenantByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTenantByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTenantByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TenantEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TenantMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TenantEntity>(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("Tenant",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TenantEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}