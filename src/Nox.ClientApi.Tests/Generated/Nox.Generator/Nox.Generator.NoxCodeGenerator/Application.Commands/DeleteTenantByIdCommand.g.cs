// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record DeleteTenantByIdCommand(IEnumerable<TenantKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTenantByIdCommandHandler : DeleteTenantByIdCommandHandlerBase
{
	public DeleteTenantByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTenantByIdCommandHandlerBase : CommandBase<DeleteTenantByIdCommand, TenantEntity>, IRequestHandler<DeleteTenantByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTenantByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTenantByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = ClientApi.Domain.TenantMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Tenants.FindAsync(keyId);
			if (entity == null)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;DbContext.Tenants.Remove(entity);
		}

		await OnCompletedAsync(request, new TenantEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}