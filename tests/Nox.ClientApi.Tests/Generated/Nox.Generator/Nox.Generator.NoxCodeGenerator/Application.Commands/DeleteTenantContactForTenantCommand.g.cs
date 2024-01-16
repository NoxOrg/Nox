﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Commands;
public partial record DeleteTenantContactForTenantCommand(TenantKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteTenantContactForTenantCommandHandler : DeleteTenantContactForTenantCommandHandlerBase
{
	public DeleteTenantContactForTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteTenantContactForTenantCommandHandlerBase : CommandBase<DeleteTenantContactForTenantCommand, TenantContactEntity>, IRequestHandler <DeleteTenantContactForTenantCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTenantContactForTenantCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTenantContactForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Tenants.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{keyId.ToString()}");
		}
		await DbContext.Entry(parentEntity).Reference(e => e.TenantContact).LoadAsync(cancellationToken);
		var entity = parentEntity.TenantContact;
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant.TenantContact",  String.Empty);
		}

		parentEntity.DeleteRefToTenantContact(entity);

		await OnCompletedAsync(request, entity);

		
		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);

		return true;
	}
}